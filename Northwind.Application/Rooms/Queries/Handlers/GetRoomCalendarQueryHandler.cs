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
    public class GetRoomCalendarQueryHandler : IRequestHandler<GetRoomCalendarQuery, RoomCalendarModel>
    {
        private readonly NorthwindDbContext _context;

        public GetRoomCalendarQueryHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<RoomCalendarModel> Handle(GetRoomCalendarQuery request, CancellationToken cancellationToken)
        {
            var roomCalendar = await _context.Dates.Where(date => date.RoomId == request.RoomId).ToListAsync();

            if (roomCalendar == null)
            {
                throw new NotFoundException(nameof(Room), request.RoomId);
            }

            return new RoomCalendarModel()
            { 
                ReservationDates = roomCalendar
            };
        }
    }
}
