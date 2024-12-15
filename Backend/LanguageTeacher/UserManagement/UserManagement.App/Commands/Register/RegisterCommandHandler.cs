using MediatR;
using Microsoft.EntityFrameworkCore;
using UserManagement.App.Repositories.Accounts;
using UserManagement.Domain.Aggregates;

namespace UserManagement.App.Commands.Register;

internal sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, Unit>
{
    private readonly IAccountRepository _accountRepository;

    public RegisterCommandHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<Unit> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if (await _accountRepository.DbSet.FirstOrDefaultAsync(x => x.Username == command.Username
                                                                 || x.Email == command.Email) is not null)
        {
            throw new ArgumentException("Username or email already used.");
        }

        var createdAccount = new Account(
            username: command.Username,
            email: command.Email,
            password: command.Password);

        await _accountRepository.DbSet.AddAsync(createdAccount);

        return Unit.Value;
    }
}