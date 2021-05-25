using System;
using System.Linq;
using USend.UserApi.Application.Dto;
using USend.UserApi.Application.Validators;
using Xunit;

namespace USend.UserApi.Test
{
    public class CreateUserDtoTest
    {
        private readonly CreateUserDto _createUser = new();
        private readonly CreateUserDtoValidator _validator = new();

        [Fact]
        public void InvalidCPFLength()
        {
            _createUser.CPF = "50";
            _createUser.Name = "Name";
            _createUser.Password = "508191981988";
            _createUser.Email = "email@test.com";
            _createUser.BirthDate = DateTime.Now.AddDays(-5);

            var result = _validator.Validate(_createUser);

            Assert.True(result.Errors.Count == 1);
        }

        [Fact]
        public void NoCPF()
        {
            _createUser.Name = "Name";
            _createUser.Password = "508191981988";
            _createUser.Email = "email@test.com";
            _createUser.BirthDate = DateTime.Now.AddDays(-5);

            var result = _validator.Validate(_createUser);

            Assert.True(result.Errors.Count == 1);
        }

        [Fact]
        public void EmptyCPF()
        {
            _createUser.Name = "Name";
            _createUser.Password = "508191981988";
            _createUser.CPF = "";
            _createUser.Email = "email@test.com";
            _createUser.BirthDate = DateTime.Now.AddDays(-5);

            var result = _validator.Validate(_createUser);

            Assert.True(result.Errors.Count == 1);
        }

        [Fact]
        public void NoName()
        {
            _createUser.CPF = "77248805068";
            _createUser.Password = "508191981988";
            _createUser.Email = "email@test.com";
            _createUser.BirthDate = DateTime.Now.AddDays(-5);

            var result = _validator.Validate(_createUser);

            Assert.True(result.Errors.Count == 1);
        }

        [Fact]
        public void EmptyName()
        {
            _createUser.CPF = "77248805068";
            _createUser.Name = "";
            _createUser.Password = "508191981988";
            _createUser.Email = "email@test.com";
            _createUser.BirthDate = DateTime.Now.AddDays(-5);

            var result = _validator.Validate(_createUser);

            Assert.True(result.Errors.Count == 1);
        }

        [Fact]
        public void NoPassword()
        {
            _createUser.CPF = "77248805068";
            _createUser.Name = "Name";
            _createUser.Email = "email@test.com";
            _createUser.BirthDate = DateTime.Now.AddDays(-5);

            var result = _validator.Validate(_createUser);

            Assert.True(result.Errors.Count == 1);
        }

        [Fact]
        public void EmptyPassword()
        {
            _createUser.CPF = "77248805068";
            _createUser.Name = "Name";
            _createUser.Password = "";
            _createUser.Email = "email@test.com";
            _createUser.BirthDate = DateTime.Now.AddDays(-5);

            var result = _validator.Validate(_createUser);

            Assert.True(result.Errors.Count == 1);
        }

        [Fact]
        public void NoEmail()
        {
            _createUser.CPF = "77248805068";
            _createUser.Name = "Name";
            _createUser.Password = "508191981988";
            _createUser.BirthDate = DateTime.Now.AddDays(-5);

            var result = _validator.Validate(_createUser);

            Assert.True(result.Errors.Count == 1);
        }

        [Fact]
        public void EmptyEmail()
        {
            _createUser.CPF = "77248805068";
            _createUser.Name = "Name";
            _createUser.Password = "508191981988";
            _createUser.BirthDate = DateTime.Now.AddDays(-5);

            var result = _validator.Validate(_createUser);

            Assert.True(result.Errors.Count == 1);
        }

        [Fact]
        public void PasswordHasMinimumLength()
        {
            _createUser.CPF = "77248805068";
            _createUser.Name = "Name";
            _createUser.Password = "123456";
            _createUser.Email = "email@test.com";
            _createUser.BirthDate = DateTime.Now.AddDays(-5);

            var result = _validator.Validate(_createUser);

            Assert.True(result.Errors.Count == 1);
        }

        [Fact]
        public void InvalidEmail()
        {
            _createUser.CPF = "77248805068";
            _createUser.Name = "Name";
            _createUser.Password = "508191981988";
            _createUser.Email = "email.com";
            _createUser.BirthDate = DateTime.Now.AddDays(-5);

            var result = _validator.Validate(_createUser);

            Assert.True(result.Errors.Count == 1);
        }

        [Fact]
        public void BirthDateGreaterThanToday()
        {
            _createUser.CPF = "77248805068";
            _createUser.Name = "Name";
            _createUser.Password = "508191981988";
            _createUser.Email = "email@test.com";
            _createUser.BirthDate = DateTime.Now.AddDays(1);

            var result = _validator.Validate(_createUser);

            Assert.True(result.Errors.Count == 1);
        }

        [Fact]
        public void ValidDto()
        {
            _createUser.CPF = "77248805068";
            _createUser.Name = "Name";
            _createUser.Password = "508191981988";
            _createUser.Email = "email@test.com";
            _createUser.BirthDate = DateTime.Now.AddDays(-5);

            var result = _validator.Validate(_createUser);

            Assert.True(!result.Errors.Any());
        }
    }
}
