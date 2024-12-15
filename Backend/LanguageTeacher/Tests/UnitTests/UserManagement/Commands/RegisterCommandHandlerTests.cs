using Moq;
using Moq.EntityFrameworkCore;
using UserManagement.App.Commands.Register;
using UserManagement.App.Repositories.Accounts;
using UserManagement.Domain.Aggregates;

namespace UnitTests.UserManagement.Commands;

[TestFixture]
public class RegisterCommandHandlerTests
{
    private Mock<IAccountRepository> _accountRepositoryMock;
    private RegisterCommandHandler _handler;

    [SetUp]
    public void Setup()
    {
        _accountRepositoryMock = new Mock<IAccountRepository>();
    }

    [Test]
    public async Task Handle_ShouldAddAccount_WhenUsernameAndEmailAreUnique()
    {
        // Arrange
        var command = new RegisterCommand("newuser", "new@example.com", "securePassword");

        var data = new List<Account>() { new Account("123", "test@test.pl", "pass") };

        _accountRepositoryMock
            .Setup(repo => repo.DbSet)
            .ReturnsDbSet(data);

        _handler = new RegisterCommandHandler(_accountRepositoryMock.Object);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        _accountRepositoryMock.Verify(
            repo => repo.DbSet.AddAsync(It.Is<Account>(
                acc => acc.Username == "newuser" &&
                       acc.Email == "new@example.com" &&
                       acc.Password == "securePassword"),
                It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Test]
    public async Task Handle_ShouldThrowArgumentException_WhenUsernameOrEmailAlreadyExists()
    {
        // Arrange
        var existingAccount = new Account("existingUser", "existing@example.com", "password123");

        var data = new List<Account>() { existingAccount };

        _accountRepositoryMock
            .Setup(repo => repo.DbSet)
            .ReturnsDbSet(data);

        var command = new RegisterCommand("existingUser", "newemail@example.com", "password123");
        _handler = new RegisterCommandHandler(_accountRepositoryMock.Object);

        // Act
        var exception = Assert.ThrowsAsync<ArgumentException>(async () =>
            await _handler.Handle(command, CancellationToken.None));

        //Assert
        Assert.AreEqual("Username or email already used.", exception.Message);

        _accountRepositoryMock.Verify(
            repo => repo.DbSet.AddAsync(
                It.IsAny<Account>(),
                It.IsAny<CancellationToken>()),
            Times.Never);
    }
}
