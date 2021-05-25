using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using USend.UserApi.Secutiry;

namespace USend.UserApi.Application.Dto
{
    [ValidateNever]
    public class AuthenticationDto
    {
        /// <summary>
        /// User e-mail
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        [Required]
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

        private string _password;
    }
}
