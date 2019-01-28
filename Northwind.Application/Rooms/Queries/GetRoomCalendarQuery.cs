using MediatR;
using Northwind.Application.Rooms.Models;

namespace Northwind.Application.Rooms.Queries
{
    public class GetRoomCalendarQuery : IRequest<RoomCalendarModel>
    {
        public int RoomId { get; set; }
    }
}
