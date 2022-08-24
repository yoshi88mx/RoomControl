using FluentValidation;
using RoomControl.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomControl.Shared.Validators
{
    public class QueueValidator : AbstractValidator<Queue>
    {
        public QueueValidator()
        {
            RuleFor(t => t.Name).NotEmpty().WithMessage("You should add a name");
        }
    }
}
