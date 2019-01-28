using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Exceptions;
using Northwind.Application.Interfaces;
using Northwind.Domain.Entities;
using Northwind.Persistence;

namespace Northwind.Application.Rooms.Commands.Handlers
{
    class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, Unit>
    {
        private readonly NorthwindDbContext _context;
        private readonly INotificationService _notificationService;

        public DeleteRoomCommandHandler(NorthwindDbContext context, INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<Unit> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _context.Rooms.FindAsync(request.RoomId);
            var dates = await _context.Dates.Where(date => date.RoomId == request.RoomId).ToListAsync();

            if (room == null)
            {
                throw new NotFoundException(nameof(Room), request.RoomId);
            }
            if (room.ReservationDates.Any(date => date.RoomId == room.RoomId && date.ReservationDate == DateTime.Today))
            {
                throw new DeleteFailureException(nameof(Room), request.RoomId, "This rooms reservation is still pending!");
            } 

            _context.Rooms.Remove(room);
            _context.Dates.RemoveRange(dates);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
