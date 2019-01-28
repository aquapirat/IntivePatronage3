using System;
using System.Collections.Generic;
using Northwind.Domain.Entities;

namespace Northwind.Application.Rooms.Models
{
    public class RoomDetailsModel
    {
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public int RoomCapacity { get; set; }

        public ICollection<Date> ReservationDates { get; set; }
    }
}
