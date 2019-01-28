using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Domain.Entities;

namespace Northwind.Persistence.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.Property(e => e.RoomId).HasColumnName("RoomId").ValueGeneratedOnAdd();
            builder.Property(e => e.RoomNumber).IsRequired();
            builder.Property(e => e.RoomCapacity).IsRequired();
        }
    }
}
