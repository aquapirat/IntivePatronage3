using System.Collections.Generic;
using MediatR;
using Northwind.Domain.Entities;

namespace Northwind.Application.Rooms.Commands
{
    public class CreateRoomCommand : IRequest
    {
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public int RoomCapacity { get; set; }

        public List<Date> ReservationDates { get; set; }
    }
}
