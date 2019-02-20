using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoManager.Models;
using FluentValidation;

namespace ToDoManager.Infrastructure
{
    public class CreateTaskListValidator : AbstractValidator<CreateUpdateTaskListModel>
    {
        public CreateTaskListValidator()
        {
            RuleFor(x => x.UserId).NotEqual(0);
            RuleFor(x => x.ListName).NotNull().MaximumLength(50);
        }
    }
}
