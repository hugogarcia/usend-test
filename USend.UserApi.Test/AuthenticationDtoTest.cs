using USend.UserApi.Application.Dto;
using USend.UserApi.Application.Validators;
using Xunit;

namespace USend.UserApi.Test
{
    public class AuthenticationDtoTest
    {
        private readonly AuthenticationDto _authenticationDto = new();
        private readonly AuthenticationDtoValidator _authenticationDtoValidator = new();

        [Fact]
        public void NoEmail()
        {
            _authenticationDto.Password = "123456789";
            var result = _authenticationDtoValidator.Validate(_authenticationDto);

            Assert.True(result.Errors.Count == 1);
        }

        [Fact]
        public void EmptyEmail()
        {
            _authenticationDto.Email = "";
            _authenticationDto.Password = "123456789";
            var result = _authenticationDtoValidator.Validate(_authenticationDto);

            Assert.True(result.Errors.Count == 1);
        }

        [Fact]
        public void NoPassword()
        {
            _authenticationDto.Email = "email@test.com";
            var result = _authenticationDtoValidator.Validate(_authenticationDto);

            Assert.True(result.Errors.Count == 1);
        }

        [Fact]
        public void EmptyPassword()
        {
            _authenticationDto.Email = "email@test.com";
            _authenticationDto.Password = "";
            var result = _authenticationDtoValidator.Validate(_authenticationDto);

            Assert.True(result.Errors.Count == 1);
        }
    }
}
