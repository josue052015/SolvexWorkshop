using FluentValidation;
using GenericApi.Bl.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Bl.Validations
{
    class WorkShopDayValidator : AbstractValidator<WorkShopDayDto>
    {
        public WorkShopDayValidator()
        {
            RuleFor(x => x.WorkShop)
                .MinimumLength(15)
                .WithMessage("WorkShop's name must be at least 15 characters")
                .NotEmpty()
                .WithMessage("WorkShop's name is required");

        }
    }

}
