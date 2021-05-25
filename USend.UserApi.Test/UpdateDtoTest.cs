using System;
using System.Linq;
using USend.UserApi.Application.Dto;
using USend.UserApi.Application.Validators;
using Xunit;

namespace USend.UserApi.Test
{
    public class UpdateDtoTest
    {
        private readonly UpdateUserDto _updateUser = new();
        private readonly UpdateUserDtoValidator _validator = new();

        [Fact]
        public void InvalidCPFLength()
        {
            _updateUser.CPF = "50";
            _updateUser.Name = "Name";
            _updateUser.BirthDate = DateTime.Now.AddDays(-5);

            var result = _validator.Validate(_updateUser);

            Assert.True(result.Errors.Count == 1);
        }

        [Fact]
        public void NoCPFOrEmail()
        {
            _updateUser.Name = "Name";
            _updateUser.BirthDate = DateTime.Now.AddDays(-5);

            var result = _validator.Validate(_updateUser);

            Assert.True(result.Errors.Count == 1);
        }       
       
        [Fact]
        public void InvalidEmail()
        {
            _updateUser.Name = "Name";
            _updateUser.Email = "email.com";
            _updateUser.BirthDate = DateTime.Now.AddDays(-5);

            var result = _validator.Validate(_updateUser);

            Assert.True(result.Errors.Count == 1);
        }

        [Fact]
        public void PasswordHasMinimumLength()
        {
            _updateUser.Name = "Name";
            _updateUser.Password = "123456";
            _updateUser.Email = "email@test.com";
            _updateUser.BirthDate = DateTime.Now.AddDays(-5);

            var result = _validator.Validate(_updateUser);

            Assert.True(result.Errors.Count == 1);
        }

        [Fact]
        public void BirthDateGreaterThanToday()
        {
            _updateUser.CPF = "77248805068";
            _updateUser.Name = "Name";
            _updateUser.Password = "508191981988";
            _updateUser.BirthDate = DateTime.Now.AddDays(1);

            var result = _validator.Validate(_updateUser);

            Assert.True(result.Errors.Count == 1);
        }

        [Fact]
        public void ValidDto()
        {
            _updateUser.CPF = "77248805068";
            _updateUser.Name = "Name";
            _updateUser.BirthDate = DateTime.Now.AddDays(-5);

            var result = _validator.Validate(_updateUser);

            Assert.True(!result.Errors.Any());
        }
    }
}
