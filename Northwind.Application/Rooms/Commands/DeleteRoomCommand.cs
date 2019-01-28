using MediatR;

namespace Northwind.Application.Rooms.Commands
{
    public class DeleteRoomCommand : IRequest
    {
        public int RoomId { get; set; }
    }
}
