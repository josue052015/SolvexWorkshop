using FluentValidation;
using GenericApi.Bl.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Bl.Validations
{
    class WorkShopMemberValidator : AbstractValidator<WorkShopMemberDto>
    {
        public WorkShopMemberValidator()
        {
            RuleFor(x => x.User)
                .MinimumLength(15)
                .WithMessage("User's name must be at least 10 characters")
                .NotEmpty()
                .WithMessage("User's name is required");

        }
    }

}
