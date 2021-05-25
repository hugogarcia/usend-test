using System;
using Usend.UserApi.Domain.Enums;
using USend.UserApi.Secutiry;

namespace Usend.UserApi.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        private string _password;        
        public string CPF { get; set; }
        public string Email { get; set; }
        public UserStatus Status { get; private set; }
        public DateTime? BirthDate { get; set; }

        public User()
        {
            Status = UserStatus.Activated;
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = Security.Encrypt(value);
            }
        }

        public void ChangeStatus()
        {
            Status = Status == UserStatus.Activated
                                ? UserStatus.Deactivated
                                : UserStatus.Activated;
        }

        
    }
}
