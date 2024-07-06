using FastEndpoints;
using FluentValidation;

namespace Todos.Todos;

public class AddTodoValidator : Validator<AddTodoCommand>
{
    public AddTodoValidator()
    {
        RuleFor(c => c.Content).NotEmpty().WithErrorCode("AddTodoValidator.Content").WithMessage("Content property cannot be empty");
    }
}
