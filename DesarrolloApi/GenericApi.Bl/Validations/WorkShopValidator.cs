﻿using FluentValidation;
using GenericApi.Bl.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Bl.Validations
{
     public class WorkShopValidator : AbstractValidator<WorkShopDto>
    {
       public WorkShopValidator()
        {
            RuleFor(x => x.Name)
                .MinimumLength(15)
                .WithMessage("WorkShop's name must be at least 15 characters")
                .NotEmpty()
                .WithMessage("WorkShop's name is required");

        }
    }

}
