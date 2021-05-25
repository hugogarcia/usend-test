using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using USend.UserApi.Application.Dto;
using USend.UserApi.Application.Interfaces;
using USend.UserApi.Application.Notifications;

namespace Usend.UserApi.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;

        public AuthenticationController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        /// <summary>
        /// Generate bearer token
        /// </summary>
        /// <param name="authentication"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(AuthenticationDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Notification>), StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("auth")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationDto authentication)
        {
            return Ok(await _authenticateService.Authorize(authentication));
        }
    }
}
