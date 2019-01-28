using FluentValidation;
using Northwind.Application.Rooms.Commands;

namespace Northwind.Application.Rooms.Validators
{
    public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
    {
        public CreateRoomCommandValidator()
        {
            RuleFor(c => c.RoomId).NotNull();
            RuleFor(c => c.RoomNumber).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(c => c.RoomCapacity).NotNull().GreaterThanOrEqualTo(0).LessThanOrEqualTo(100);
        }
    }
}
