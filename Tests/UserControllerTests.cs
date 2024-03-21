using SHC.Controllers;
using SHC.Services;
using SHC.Utilities;
using SHC.Entities;


namespace Tests
{
    public class UserControllerTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<IUserService> _userServiceMock;
        private readonly UserController _userController;

        public UserControllerTests()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            _userServiceMock = _fixture.Freeze<Mock<IUserService>>();
            _userController = new UserController(_userServiceMock.Object);
        }


        [Fact]
        public async void HandleRegisterRequest_ShouldReturnString_WhenNullRequest()
        {
            // Arrange
            var request = _fixture.Create<RegisterRequest>();

            // Act
            var result = await _userController.HandleRegisterRequest(null);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<string>();
            result.Should().Be("request is null.");

        }

        [Fact]
        public async void HandleRegisterRequest_ShouldReturnString_WhenNullFirstName()
        {
            // Arrange
            var request = _fixture.Create<RegisterRequest>();
            request.FirstName = null;

            // Act
            var result = await _userController.HandleRegisterRequest(request);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<string>();
            result.Should().Be("Invalid request: FirstName is null\n");
        }


        [Fact]
        public async void HandleRegisterRequest_ShouldReturnString_WhenNullLastName()
        {
            // Arrange
            var request = _fixture.Create<RegisterRequest>();
            request.LastName = null;

            // Act
            var result = await _userController.HandleRegisterRequest(request);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<string>();
            result.Should().Be("Invalid request: LastName is null\n");
        }

        [Fact]
        public async void HandleRegisterRequest_ShouldReturnString_WhenNullEmail()
        {
            // Arrange
            var request = _fixture.Create<RegisterRequest>();
            request.Email = null;

            // Act
            var result = await _userController.HandleRegisterRequest(request);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<string>();
            result.Should().Be("Invalid request: Email is null\n");
        }

        [Fact]
        public async void HandleRegisterRequest_ShouldReturnString_WhenNullPassword()
        {
            // Arrange
            var request = _fixture.Create<RegisterRequest>();
            request.Password = null;

            // Act
            var result = await _userController.HandleRegisterRequest(request);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<string>();
            result.Should().Be("Invalid request: Password is null\n");
        }


        [Fact]
        public async void HandleRegisterRequest_ShouldReturnString_WhenNullPasswordConfirm()
        {
            // Arrange
            var request = _fixture.Create<RegisterRequest>();
            request.PasswordConfirm = null;

            // Act
            var result = await _userController.HandleRegisterRequest(request);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<string>();
            result.Should().Be("Invalid request: PasswordConfirm is null\n");
        }

        [Fact]
        public async void HandleRegisterRequest_ShouldReturnString_WhenValidRequest()
        {
            // Arrange
            var request = _fixture.Create<RegisterRequest>();
            request.PasswordConfirm = request.Password;

            _userServiceMock.Setup(x => x.HandleRegisterRequest(request)).ReturnsAsync("User Creation Successful! Please log in to continue.");

            // Act
            var result = await _userController.HandleRegisterRequest(request);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<string>();
            result.Should().Be("User Creation Successful! Please log in to continue.");
        }


        [Fact]
        public async void Login_ShouldReturnString_WhenNullRequest()
        {
            // Arrange
            var request = _fixture.Create<LoginRequest>();

            _userServiceMock.Setup(x => x.Login(request)).ReturnsAsync(
                ("Login Successful", null)
                );

            // Act
            var result = await _userController.Login(null);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<(string, VirtualUser)>();
            result.Should().Be(("request is null.\n", null));
        }

        [Fact]
        public async void Login_ShouldReturnString_WhenNullEmail()
        {
            // Arrange
            var request = _fixture.Create<LoginRequest>();
            request.Email = null;

            _userServiceMock.Setup(x => x.Login(request)).ReturnsAsync(
                ("Login Successful", null)
                );

            // Act
            var result = await _userController.Login(request);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<(string, VirtualUser)>();
            result.Should().Be(("Email is null\n", null));
        }

        [Fact]
        public async void Login_ShouldReturnString_WhenNullPassword()
        {
            // Arrange
            var request = _fixture.Create<LoginRequest>();
            request.Password = null;

            _userServiceMock.Setup(x => x.Login(request)).ReturnsAsync(
                ("Login Successful", null)
                );

            // Act
            var result = await _userController.Login(request);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<(string, VirtualUser)>();
            result.Should().Be(("Password is null\n", null));
        }


        [Fact]
        public async void Login_ShouldReturnString_WhenValidRequest()
        {
            // Arrange
            var request = _fixture.Create<LoginRequest>();

            _userServiceMock.Setup(x => x.Login(request)).ReturnsAsync(
                ("Login Successful", null)
                );

            // Act
            var result = await _userController.Login(request);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<(string, VirtualUser)>();
            result.Should().Be(("Login Successful", null));
        }


    }
}