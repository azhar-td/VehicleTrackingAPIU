using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleLogger;
using VehicleServices.Interfaces;
using VehicleTracking.DTO;

namespace VehicleTracking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {
        private ILoggerManager _logger;
        private IMapper _mapper;
        private IUserService _userService;
        private IUserLoginService _userLoginService;
        public UserController(ILoggerManager logger,IMapper mapper,IUserService userService,IUserLoginService userLoginService)
        {
            _logger = logger;
            _mapper = mapper;
            _userService = userService;
            _userLoginService = userLoginService;
        }
        // GET: api/User
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = await _userService.GetAllUsers();
                _logger.LogInfo($"Returned all users from database.");

                var usersResult = _mapper.Map<IEnumerable<VMUser>>(users);
                return Ok(usersResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllUsers action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateUser([FromBody]VMUser userParam)
        {
            try
            {
                var user = await _userService.Authenticate(userParam.Email, userParam.Password);

                if (user == null)
                    return BadRequest(new { message = "Email or password is incorrect" });
                _logger.LogInfo($"User available in database.");
                //Get latest token from DB
                var userLogin = await _userLoginService.GetLatestToken(user.Id);
                HttpContext.Session.SetString("JWToken", userLogin.Token);
                var userResult = _mapper.Map<VMUser>(user);
                return Ok(userResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Authenticate or GetLatestToken action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
