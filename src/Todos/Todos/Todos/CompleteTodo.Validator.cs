using FastEndpoints;
using FluentValidation;

namespace Todos.Todos;

public class CompleteTodoValidator : Validator<Guid>
{
    public CompleteTodoValidator()
    {
        RuleFor(e => e).Must(e => e != Guid.Empty || e != default).WithErrorCode("CompleteTodoValidator.Id").WithMessage("Id må være gyldig verdi");
    }
}
