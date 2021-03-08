using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VehicleData.Models;
using VehicleLogger;
using VehicleServices.Interfaces;
using VehicleTracking.DTO;

namespace VehicleTracking.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private ILoggerManager _logger;
        private IMapper _mapper;
        private IUserService _userService;
        private IUserLoginService _userLoginService;
        public AdminController(ILoggerManager logger, IMapper mapper, IUserService userService,IUserLoginService userLoginService)
        {
            _logger = logger;
            _mapper = mapper;
            _userService = userService;
            _userLoginService = userLoginService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            var vmUser = new VMUser();
            return View(vmUser);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(VMUser userD)
        {
            try
            {
                var user = await _userService.Authenticate(userD.Email, userD.Password);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Username and Password does not match!!!");
                    return View();
                }
                _logger.LogInfo($"User available in database.");
                //Get latest token from DB
                var userLogin = await _userLoginService.GetLatestToken(user.Id);
                HttpContext.Session.SetString("JWToken", userLogin.Token);
                var userResult = _mapper.Map<VMUser>(user);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong inside Authenticate or GetLatestToken action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
            return RedirectToAction("HomePage");
        }
        [HttpGet]
        public IActionResult HomePage(int id=1)
        {
            try
            {
                int page = id;
                List<Vehicle> vehicleList = new List<Vehicle>();
                using (var client = new HttpClient())
                {
                    var JWToken = HttpContext.Session.GetString("JWToken");
                    if (!string.IsNullOrEmpty(JWToken))
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JWToken);
                    }
                    var response = client.GetAsync("https://localhost:44321/api/vehicle/GetPagedData/" + page).Result;


                    if (response.IsSuccessStatusCode)
                    {
                        _logger.LogInfo($"Vehicles available in database.");
                        vehicleList = response.Content.ReadAsAsync<IEnumerable<Vehicle>>().Result.ToList();
                    }
                    else //web api sent error response 
                    {
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
                var vehicleResult = _mapper.Map<IEnumerable<VMVehicle>>(vehicleList);
                return View(vehicleResult);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetPagedData method: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet]
        public IActionResult test()
        {
            var vmUser = new VMUser();
            return View(vmUser);
        }
    }
}