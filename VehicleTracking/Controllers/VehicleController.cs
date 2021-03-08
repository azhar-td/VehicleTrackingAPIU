using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleData.Models;
using VehicleLogger;
using VehicleServices.Interfaces;
using VehicleTracking.DTO;

namespace VehicleTracking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class VehicleController : ControllerBase
    {
        private ILoggerManager _logger;
        private IMapper _mapper;
        private IVehicleService _vehicleService;
        private IVehicleLoginService _vehicleLoginService;
        private IVehiiclePositionService _vehiclePositionService;
        public VehicleController(ILoggerManager logger, IMapper mapper, IVehicleService vehicleService,IVehicleLoginService vehicleLoginService,IVehiiclePositionService vehiclePositionService)
        {
            _logger = logger;
            _mapper = mapper;
            _vehicleService = vehicleService;
            _vehicleLoginService = vehicleLoginService;
            _vehiclePositionService = vehiclePositionService;
        }
        // GET: api/Vehicle
        [HttpGet("GetAllVehicles")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var vehicles = await _vehicleService.GetAllVehicleAsync();
                _logger.LogInfo($"Returned all vehicles from database.");

                var vehicleResult = _mapper.Map<IEnumerable<VMVehicle>>(vehicles);
                return Ok(vehicleResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllVehicle action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        //Get: get by pagination
        [HttpGet]
        [Route("GetPagedData/{page}")]
        public async Task<IActionResult> GetByPage(int page=1)
        {
            try
            {
                var vehicles = await _vehicleService.GetAllByPageAsync(page);
                _logger.LogInfo($"Returned all vehicles by pagination from database.");

                var vehicleResult = _mapper.Map<IEnumerable<VMVehicle>>(vehicles);
                return Ok(vehicleResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllByPageAsync action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        // GET: api/Vehicle/5
        [HttpGet("{id}", Name = "GetVehicleById")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var vehicle = await _vehicleService.GetByIdAsync(id);
                _logger.LogInfo($"Vehicle found in database.");

                var vehicleResult = _mapper.Map<VMVehicle>(vehicle);
                return Ok(vehicleResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetByIdAsync action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/Vehicle
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody] VMVehicle vehicleD)
        {
            try
            {
                if (ModelState.IsValid && vehicleD.Model.ToLower()!="string" && vehicleD.RegNum.ToLower()!="string")
                {
                    var existingV = await _vehicleService.GetByRegnumAsync(vehicleD.RegNum);
                    if (existingV != null)
                    {
                        return BadRequest("Vehicle with this registration number is already exist.");
                    }
                    var vehicle = _mapper.Map<Vehicle>(vehicleD);
                    await _vehicleService.RegisterVehicle(vehicle);
                    _logger.LogInfo($"Vehicle registered in database.");
                    return Ok("Vehicle registered please sign in vehicle to sync with system!!");
                }
                else
                    return BadRequest("Validation error");
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong inside RegisterVehicle method: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateVehicle([FromBody]VMVehicle userParam)
        {
            try
            {
                var vehicle = await _vehicleService.Authenticate(userParam.RegNum, userParam.Password);

                if (vehicle == null)
                    return BadRequest(new { message = "Registration or password is incorrect" });
                _logger.LogInfo($"Vehicle available in database.");
                //Get latest token from DB
                var vehicleLogin = await _vehicleLoginService.GetLatestToken(vehicle.Id);
                HttpContext.Session.SetString("VehicleToken", vehicleLogin.Token);
                var vehicleResult = _mapper.Map<VMVehicle>(vehicle);
                HttpContext.Session.SetString("LoggedVehicle", vehicle.RegNum);
                return Ok(vehicleResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Authenticate or GetLatestToken action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost("vehiclePosition")]
        public async Task<IActionResult> VehiclePosition([FromBody]VMVehiclePosition userParam)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var loggedVehicleR = HttpContext.Session.GetString("LoggedVehicle");
                    if (loggedVehicleR == userParam.RegNum)
                    {
                        var v = await _vehicleService.GetByRegnumAsync(userParam.RegNum);
                        var vehiclePosition = _mapper.Map<VehiclePosition>(userParam);
                        vehiclePosition.TimeStamp = DateTime.Now;
                        vehiclePosition.VehicleId = v.Id;
                        await _vehiclePositionService.VehiclePosition(vehiclePosition);

                        _logger.LogInfo($"Vehicle position saved in database.");
                        return Ok("Position update in DB");
                    }
                    return BadRequest("Vehicle is not authorized to updated location");
                }
                return BadRequest("Validation error");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside position action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        //[HttpGet("getCurrentPosition")]
        //public async Task<IActionResult> GetCurrentVehiclePosition()
        //{

        //}
    }
}
