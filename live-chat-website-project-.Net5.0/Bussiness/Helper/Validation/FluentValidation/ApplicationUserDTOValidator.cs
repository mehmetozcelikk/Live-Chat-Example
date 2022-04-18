using Entities.ViewModel;
using FluentValidation;

namespace Business.Helper.Validation.FluentValidation
{
    public class ApplicationUserDTOValidator : AbstractValidator<ApplicationUserDTO>
    {
        public ApplicationUserDTOValidator()
        {

            RuleFor(c => c.Email).NotNull().NotEmpty().EmailAddress().WithMessage("emaili dogru giriniz");
            RuleFor(c => c.Password).NotNull().NotEmpty().WithMessage("şifre alanı boşş olamaz");


        }
    }
}
