using System;

namespace USend.UserApi.Application.Dto
{
    public class JwtDto
    {
        /// <summary>
        /// Bearer token
        /// </summary>
        public string Access_token { get; set; }

        /// <summary>
        /// Expiration time
        /// </summary>
        public DateTime Expires_in { get; set; }
    }
}
