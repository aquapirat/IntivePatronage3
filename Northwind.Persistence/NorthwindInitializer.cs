using System;
using System.Collections.Generic;
using System.Linq;
using Northwind.Domain.Entities;
using Northwind.Persistence.Infrastructure;

namespace Northwind.Persistence
{
    public class NorthwindInitializer
    {
        private readonly Dictionary<int, Room> Rooms = new Dictionary<int, Room>();

        public static void Initialize(NorthwindDbContext context)
        {
            var initializer = new NorthwindInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(NorthwindDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Rooms.Any())
            {
                return;
            }

            SeedRooms(context);
        }

        public void SeedRooms(NorthwindDbContext context)
        {
            var rooms = new[]
            {
                new Room() {RoomId = 1, RoomNumber = 15, RoomCapacity = 30},
                new Room() {RoomId = 2, RoomNumber = 15, RoomCapacity = 30},
                new Room() {RoomId = 3, RoomNumber = 15, RoomCapacity = 30},
                new Room() {RoomId = 4, RoomNumber = 15, RoomCapacity = 30},
                new Room() {RoomId = 5, RoomNumber = 15, RoomCapacity = 30},
                new Room() {RoomId = 6, RoomNumber = 15, RoomCapacity = 30}
            };

            context.Rooms.AddRange(rooms);

            context.SaveChanges();
        }
    }
}