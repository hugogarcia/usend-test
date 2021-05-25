using Usend.UserApi.Domain.Entities;
using Usend.UserApi.Domain.Enums;
using Xunit;

namespace USend.UserApi.Test
{
    public class UserTest
    {
        [Fact]
        public void StatusChanged()
        {
            var user = new User();
            user.ChangeStatus();

            Assert.Equal(UserStatus.Deactivated, user.Status);
        }

        [Fact]
        public void PasswordEncrypt()
        {
            var password = "123456789";
            var user = new User
            {
                Password = password
            };

            Assert.NotEqual(password, user.Password);
        }
    }
}
