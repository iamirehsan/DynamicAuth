using DynamicAuth.Infrastructure.Base;
using DynamicAuth.Messages.Commands;
using DynamicAuth.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicAuth.Controllers
{
    [Route("api/auth/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceHolder _serviceHolder;

        public UserController(IServiceHolder serviceHolder)
        {
            _serviceHolder = serviceHolder;
        }

        [HttpPost("Signin")]
        public async Task<IActionResult> Signin(SigninCommand cmd)
        {
            try
            {
                var result = await _serviceHolder.UserFunctionsService.Signin(cmd);
                return Ok(result);
           
            }
            catch (ManagedException ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpPost("Signup")]
        public async  Task<IActionResult> Signup(SignupCommand cmd)
        {
            try
            {
                await _serviceHolder.UserFunctionsService.Signup(cmd);
                return Ok("کاربر با موفقیت ساخته شد");

            }
            catch (ManagedException ex)
            {

                return BadRequest(ex.ErrorMessage);
            }
        }
    }
}
