using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VehicleLogger;
using VehicleServices.Interfaces;
using VehicleTracking.DTO;

namespace VehicleTracking.Controllers
{
    public class TrackingController : Controller
    {
        private ILoggerManager _logger;
        private IMapper _mapper;
        private IVehicleService _vehicleService;
        private IVehiiclePositionService _vehiclePositionService;
        public TrackingController(ILoggerManager logger, IMapper mapper, IVehicleService vehicleService, IVehiiclePositionService vehiclePositionService)
        {
            _logger = logger;
            _mapper = mapper;
            _vehicleService = vehicleService;
            _vehiclePositionService = vehiclePositionService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> VDetail(int id)
        {
            VehicleAndPosition model = new VehicleAndPosition();
            try
            {
                var v= await _vehicleService.GetByIdAsync(id);
                model.Vehicle = _mapper.Map<VMVehicle>(v);
                var c = await _vehiclePositionService.GetCurrentLocationByVehicleIdAsync(id);
                model.VehiclePosition = _mapper.Map<VMVehiclePosition>(c);
                var p = await _vehiclePositionService.GetAllPositionsByVehicleIdAsync(id);
                model.PositionList = _mapper.Map<IEnumerable<VMVehiclePosition>>(p).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Detail action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
            return View(model);
        }
    }
}