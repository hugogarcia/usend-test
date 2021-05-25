using System;
using Usend.UserApi.Domain.Enums;

namespace USend.UserApi.Application.Dto
{
    public class UserDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// CPF unformatted
        /// </summary>
        public string CPF { get; set; }

        /// <summary>
        /// E-mail
        /// </summary>
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
        /// Image URL location
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Created date
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Updated date
        /// </summary>
        public DateTime UpdatedOn { get; set; }
    }
}
