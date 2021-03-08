using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleData.Models;

namespace VehicleServices.Interfaces
{
    public interface IVehicleLoginService
    {
        Task<IEnumerable<VehicleLogin>> GetAllByVehicleIdAsync(int vehicleId);
        Task<VehicleLogin> GetLatestToken(int vehicleId);
    }
}
