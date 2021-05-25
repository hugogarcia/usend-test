using FluentValidation;
using System;
using USend.UserApi.Application.Dto;

namespace USend.UserApi.Application.Validators
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            RuleFor(x => x)
                .Must(x => !string.IsNullOrEmpty(x.Email) || !string.IsNullOrEmpty(x.CPF))
                .WithMessage("CPF or E-mail must be informed!");

            RuleFor(x => x)
                .Must(x => !(!string.IsNullOrEmpty(x.Email) && !string.IsNullOrEmpty(x.CPF)))
                .WithMessage("Enter only one field, E-mail or CPF!");

            RuleFor(x => x.CPF)
                .Length(11);

            RuleFor(x => x.Password)
                .MinimumLength(8);

            RuleFor(x => x.Status)
                .IsInEnum()
                .WithMessage("Invalid status.");

            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Invalid email.");

            RuleFor(x => x.BirthDate)
                .LessThan(DateTime.Now);
        }
    }
}
