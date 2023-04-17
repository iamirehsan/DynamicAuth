using DynamicAuth.Base;
using DynamicAuth.Infrastructure.Base;
using DynamicAuth.Messages.Commands;
using DynamicAuth.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicAuth.Controllers
{
    [Route("api/auth/[controller]")]
    [ApiController]
    public class UserController : ApiControllerBase
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
                return Ok(new ResponseMessage("ورود کاربر با موفقیت صورت گرفت. " ,result,result.Count()));
           
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
                return Ok(new ResponseMessage("ثبت نام با موفقیت صورت گرفت. "));

            }
            catch (ManagedException ex)
            {

                return BadRequest(ex.ErrorMessage);
            }
        }
        [HttpPost("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordCommand cmd)
        {
            try
            {
                await _serviceHolder.UserFunctionsService.UpdatePassword(cmd,UserId);
                return Ok(new ResponseMessage("رمز کاربر با موفقیت تغییر کرد."));

            }
            catch (ManagedException ex)
            {

                return BadRequest(ex.ErrorMessage);
            }
        }
        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand cmd)
        {
            try
            {
                await _serviceHolder.UserFunctionsService.UpdateUser(cmd, UserId);
                return Ok(new ResponseMessage("اطلاعات کاربر با موفقیت تغییر کرد."));

            }
            catch (ManagedException ex)
            {

                return BadRequest(ex.ErrorMessage);
            }
        }
    }
}
