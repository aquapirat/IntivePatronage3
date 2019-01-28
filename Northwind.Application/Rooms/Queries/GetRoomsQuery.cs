using MediatR;
using Northwind.Application.Rooms.Models;

namespace Northwind.Application.Rooms.Queries
{
    public class GetRoomsQuery : IRequest<RoomListModel>
    {
    }
}
