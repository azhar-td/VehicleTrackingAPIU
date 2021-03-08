using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleData.Models;

namespace VehicleServices.Interfaces
{
    public interface IVehiiclePositionService
    {
        Task<VehiclePosition> GetCurrentLocationByVehicleIdAsync(int vehcileid);
        Task<IEnumerable<VehiclePosition>> GetAllPositionsByVehicleIdAsync(int vehcileid);
        Task<VehiclePosition> GetByIdAsync(int id);
        Task VehiclePosition(VehiclePosition vehiclePosition);
    }
}
