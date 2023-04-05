using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Webapi.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.id).GreaterThan(0);
            RuleFor(command => command.model.GenreId).GreaterThan(0);
            RuleFor(command => command.model.Title).NotEmpty().MinimumLength(4);
        }
    }
}