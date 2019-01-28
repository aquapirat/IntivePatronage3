using System;
using System.Collections.Generic;
using System.Text;
using Northwind.Domain.Entities;

namespace Northwind.Application.Rooms.Models
{
    public class RoomCalendarModel
    {
        public ICollection<Date> ReservationDates { get; set; }
    }
}
