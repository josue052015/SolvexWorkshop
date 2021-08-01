using FluentValidation;
using GenericApi.Bl.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Bl.Validations
{
    public class DocumentValidator : AbstractValidator<DocumentDto>
    {
		public DocumentValidator()
		{
			RuleFor(x => x.FileName)
				.MinimumLength(5)
				.WithMessage("Document's length must be at least 5 characters")
				.NotEmpty()
				.WithMessage("Document's filename is required");
		}
	}
}
