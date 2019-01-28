using System.Collections.Generic;
using MediatR;
using Northwind.Domain.Entities;

namespace Northwind.Application.Rooms.Commands
{
    public class UpdateRoomCommand : IRequest
    {
        public int? RoomId { get; set; }
        public int RoomNumber { get; set; }
        public int RoomCapacity { get; set; }

        public ICollection<Date> ReservationDates { get; set; }
    }
}
