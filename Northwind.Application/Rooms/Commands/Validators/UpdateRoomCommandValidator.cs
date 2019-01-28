using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Northwind.Application.Rooms.Commands.Validators
{
    class UpdateRoomCommandValidator : AbstractValidator<UpdateRoomCommand>
    {
        UpdateRoomCommandValidator()
        {
            RuleFor(c => c.RoomNumber).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(c => c.RoomCapacity).NotNull().GreaterThanOrEqualTo(0).LessThanOrEqualTo(100);
        }
    }
}
