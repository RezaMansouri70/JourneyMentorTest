using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Flight.Command.Validations
{

    public class GetFlightsCommandValidator : AbstractValidator<GetFlightsCommand>
    {
        public GetFlightsCommandValidator()
        {
            RuleFor(command => command.PageIndex)
                .NotEmpty().WithMessage("Please inter pageindex.")
                .GreaterThanOrEqualTo(1).WithMessage("Min. number of pageindex must be greater than or equal to 1.");

            RuleFor(command => command.PageSize)
                .NotEmpty().WithMessage("Please inter pagesize.")
                .GreaterThanOrEqualTo(1).WithMessage("Min. number of pagesize must be greater than or equal to 1.")
                .LessThanOrEqualTo(50).WithMessage("Min. number of pagesize must be less than 50.");
        }
    }
}
