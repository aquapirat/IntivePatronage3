using MediatR;
using Northwind.Application.Rooms.Models;

namespace Northwind.Application.Rooms.Queries
{
    public class GetRoomDetailsQuery : IRequest<RoomDetailsModel>
    {
        public int RoomId { get; set; }
    }
}
