using FluentValidation;
using MediatR;

namespace Application.Account;

public abstract class Login
{
    public abstract class LoginCommand : IRequest<Unit>
    {
        protected LoginCommand(string password, string email)
        {
            Password = password;
            Email = email;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).NotEmpty().NotNull();
        }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, Unit>
    {
        public Task<Unit> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Unit.Value);
        }
    }
}