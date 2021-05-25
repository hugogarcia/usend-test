using System;
using Usend.UserApi.Domain.Enums;

namespace USend.UserApi.Application.Dto
{
    public class UpdateUserDto
    {
        /// <summary>
        /// Unformatted CPF. Key to find the user.
        /// <param>It can't be informed with Email at the same time.</param>
        /// </summary>
        public string CPF { get; set; }

        /// <summary>
        /// Email. Must be a valid email format. Key to find the user.
        /// <param>It can't be informed with CPF at the same time.</param>
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Password
        /// <para>Minimum length: 8</para>
        /// </summary>
        public string Password { get; set; }

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
