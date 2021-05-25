using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using USend.UserApi.Application.Dto;
using USend.UserApi.Application.Interfaces;
using USend.UserApi.Application.Notifications;

namespace Usend.UserApi.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/user")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(IEnumerable<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAll();
            if (!users.Any())
                return NotFound();

            return Ok(users);
        }

        /// <summary>
        /// Get user by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        [Route("id/{id}")]
        public async Task<IActionResult> GetById([BindRequired] Guid id)
        {
            var user = await _userService.GetById(id);
            if (user is null)
                return NotFound();

            return Ok(user);
        }

        /// <summary>
        /// Get user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        [Route("email/{email}")]
        public async Task<IActionResult> GetByEmail([Required] string email)
        {
            var user = await _userService.GetByEmail(email);
            if (user is null)
                return NotFound();

            return Ok(user);
        }

        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(List<Notification>), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserDto user)
        {
            _userService.Create(user);
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="user"></param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Notification>), StatusCodes.Status400BadRequest)]
        [HttpPut]
        public void Put([FromBody] UpdateUserDto user)
            => _userService.Update(user);

        /// <summary>
        /// Change user status - Activate or deactivate
        /// </summary>
        /// <param name="email"></param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Notification>), StatusCodes.Status400BadRequest)]
        [HttpPatch]
        [Route("change-status/{email}")]
        public void ChangeStatus([Required] string email)
            => _userService.ChangeStatus(email);
    }
}
