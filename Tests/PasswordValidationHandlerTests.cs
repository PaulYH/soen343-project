using SHC.Controllers;
using SHC.Services;
using SHC.Utilities;
using SHC.Entities;

namespace Tests
{
    public class PasswordValidationHandlerTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<IUserService> _userServiceMock;
        private readonly PasswordValidationHandler _handler;

        public PasswordValidationHandlerTests()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            _userServiceMock = _fixture.Freeze<Mock<IUserService>>();
            _handler = new PasswordValidationHandler(_userServiceMock.Object);
        }

        [Fact]
        public async void HandleRegisterRequest_ShouldReturnString_WhenBadPassword()
        {
            // Arrange
            var request = _fixture.Create<RegisterRequest>();
            request.Password = "";
            request.PasswordConfirm = request.Password + " ";

            // Act
            var result = await _handler.HandleRegisterRequest(request);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<string>();
            result.Should().Be("Invalid Password: Passwords do not match.\n" +
                "Password is below the miminum length of 8 characters.\n" +
                "Password does not contain a digit.\n" +
                "Password does not contain a lowercase letter.\n" +
                "Password does not contain an uppercase letter.");
        }



    }
}
