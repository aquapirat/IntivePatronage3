using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Domain.Entities
{
    public class Date
    {
        public int DateId { get; set; }
        public int RoomId { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}
