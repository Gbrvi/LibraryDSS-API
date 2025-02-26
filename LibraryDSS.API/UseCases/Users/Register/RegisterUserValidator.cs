using FluentValidation;
using LibraryDSS.Communication.Request;

namespace LibraryDSS.API.UseCases.Users.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestUserJson>
    {
        public RegisterUserValidator() // Validacao do usuario
        {
            RuleFor(request => request.Name).NotEmpty().WithMessage("O nome é obrigatório");
            RuleFor(request => request.Email).EmailAddress().WithMessage("O email é inválido");
            When(request => string.IsNullOrEmpty(request.Password) == false, () =>
            {
                RuleFor(request => request.Password.Length).GreaterThanOrEqualTo(6).WithMessage("Precisa ter 6 caracteres minimo");
            });
        }
    }
}
