using Core.Abstraction.IUserService;
using Core.ViewModel;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WorkForce.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        public async Task<IActionResult> GetUser(string UserName)
        {
            var result = await _userService.GetUser(UserName);
            if (result != null)
                return new OkObjectResult(result);
            else
                return new NoContentResult();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SoftLock))]
        public async Task<IActionResult> CreateUser(UserDto user)
        {
            await _userService.CreateUser(user);
            return new OkObjectResult(user);
        }

    }
}
