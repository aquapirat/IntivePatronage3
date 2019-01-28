using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Northwind.Application.Exceptions;
using Northwind.Domain.Entities;
using Northwind.Persistence;

namespace Northwind.Application.Rooms.Commands.Handlers
{
    class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, Unit>
    {
        private readonly NorthwindDbContext _context;

        public UpdateRoomCommandHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _context.Rooms.FindAsync(request.RoomId);

            if (room == null)
            {
                throw new NotFoundException(nameof(Room), request.RoomId);
            }

            room.RoomNumber = request.RoomNumber;
            room.RoomCapacity = request.RoomCapacity;
            room.ReservationDates = request.ReservationDates;

            _context.Rooms.Update(room);

            if (request.ReservationDates != null)
            {
                AddOrUpdateDatesRangeAsync(request.ReservationDates);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private async void AddOrUpdateDatesRangeAsync(IEnumerable<Date> dates)
        {
            foreach (var date in dates)
            {
                var dbDate = await _context.Dates.FindAsync(date.DateId);

                if (dbDate == null)
                {
                    _context.Dates.Add(date);
                }
                else
                {
                    _context.Dates.Update(date);
                }
            }
        }
    }
}
