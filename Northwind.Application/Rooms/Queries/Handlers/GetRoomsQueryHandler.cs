using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Rooms.Models;
using Northwind.Persistence;

namespace Northwind.Application.Rooms.Queries.Handlers
{
    public class GetRoomsQueryHandler : IRequestHandler<GetRoomsQuery, RoomListModel>
    {
        private readonly NorthwindDbContext _context;

        public GetRoomsQueryHandler(NorthwindDbContext context)
        {
            _context = context;
        }

        public async Task<RoomListModel> Handle(GetRoomsQuery request, CancellationToken cancellationToken)
        {
            var roomsPreview = from room in _context.Rooms
                select new RoomPreviewModel()
                {
                    RoomId = room.RoomId,
                    RoomNumber = room.RoomNumber,
                    RoomCapacity = room.RoomCapacity
                };

            return new RoomListModel
            {
                Rooms = await roomsPreview.ToListAsync(cancellationToken)
            };
        }
    }
}
