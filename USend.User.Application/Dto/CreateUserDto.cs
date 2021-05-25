using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using Usend.UserApi.Domain.Enums;

namespace USend.UserApi.Application.Dto
{
    [ValidateNever]
    public class CreateUserDto
    {
        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Password
        /// <para>Minimum length: 8</para>
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// Unformatted CPF
        /// <para>Length: 11</para>
        /// </summary>
        [Required]
        public string CPF { get; set; }

        /// <summary>
        /// Email. Must be a valid email format.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// User status
        /// <para>1 - Activated</para>
        /// <para>2 - Deactivated</para>
        /// </summary>
        public UserStatus Status { get; set; }

        /// <summary>
        /// Birth date
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Image. Must be in base64 format
        /// </summary>
        public string Image { get; set; }
    }
}
