using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoManager.Models;
using FluentValidation;

namespace ToDoManager.Infrastructure
{
    public class RegistrationValidator : AbstractValidator<RegistrationModel>
    {
        public RegistrationValidator()
        {
            RuleFor(x => x.FullName).NotNull().MaximumLength(50);
            RuleFor(x => x.Email).NotNull().EmailAddress().MaximumLength(50);
            RuleFor(x => x.Password).NotNull().Length(5, 50);
        }
    }
}
