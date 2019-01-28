using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Exceptions;
using Northwind.Application.Rooms.Models;
using Northwind.Domain.Entities;
using Northwind.Persistence;

namespace Northwind.Application.Rooms.Queries.Handlers
{
    public class GetRoomDetailsQueryHandler : IRequestHandler<GetRoomDetailsQuery, RoomDetailsModel>
    {
        private readonly NorthwindDbContext _context;

        public GetRoomDetailsQueryHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<RoomDetailsModel> Handle(GetRoomDetailsQuery request, CancellationToken cancellationToken)
        {
            var room = await _context.Rooms.FindAsync(request.RoomId);
            var reservationDates = await _context.Dates.Where(i => i.RoomId == room.RoomId).ToListAsync();

            if (room == null)
            {
                throw new NotFoundException(nameof(Room), request.RoomId);
            }

            return new RoomDetailsModel()
            {
                RoomId = room.RoomId,
                RoomNumber = room.RoomNumber,
                RoomCapacity = room.RoomCapacity,
                ReservationDates = reservationDates
            };
        }
    }
}
