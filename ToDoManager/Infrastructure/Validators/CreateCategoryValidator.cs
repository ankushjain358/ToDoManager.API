using FluentValidation;
using ToDoManager.Models;

namespace ToDoManager.Infrastructure
{
    public class CreateCategoryValidator : AbstractValidator<CreateUpdateCategoryModel>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.UserId);
            RuleFor(x => x.Name).NotNull().MaximumLength(50);
        }
    }
}
