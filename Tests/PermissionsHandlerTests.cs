using SHC.Controllers;
using SHC.Services;
using SHC.Utilities;
using SHC.Entities;

namespace Tests
{
    public class PermissionsHandlerTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<IUserService> _userServiceMock;
        private readonly PermissionsHandler _handler;

        public PermissionsHandlerTests()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            _userServiceMock = _fixture.Freeze<Mock<IUserService>>();
            _handler = new PermissionsHandler(_userServiceMock.Object);
        }

        [Fact]
        public async void HandleRegisterRequest_ShouldReturnString_WhenValidRequest()
        {
            // Arrange
            var request = _fixture.Create<RegisterRequest>();
            _userServiceMock.Setup(x => x.HandleRegisterRequest(request)).ReturnsAsync("User Creation Successful! Please log in to continue.");


            // Act
            var result = await _handler.HandleRegisterRequest(request);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<string>();
            result.Should().Be("User Creation Successful! Please log in to continue.");
        }



    }
}
