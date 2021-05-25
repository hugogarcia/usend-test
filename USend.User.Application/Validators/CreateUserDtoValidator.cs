using FluentValidation;
using System;
using USend.UserApi.Application.Dto;

namespace USend.UserApi.Application.Validators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.CPF).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();

            RuleFor(x => x.CPF)
                .Length(11)
                .When(x => !string.IsNullOrEmpty(x.CPF));

            RuleFor(x => x.Password)
                .MinimumLength(8)
                .When(x => !string.IsNullOrEmpty(x.Password));

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
