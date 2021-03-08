using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleData.Models;

namespace VehicleServices.Interfaces
{
    public interface IVehicleService
    {
        Task<Vehicle> Authenticate(string reg, string password);
        Task<IEnumerable<Vehicle>> GetAllVehicleAsync();
        Task<Vehicle> GetByIdAsync(int vehicleId);
        Task<Vehicle> GetByRegnumAsync(string reg);
        Task<IEnumerable<Vehicle>> GetAllByModelAsync(string model);
        Task RegisterVehicle(Vehicle vehicle);
        Task<IEnumerable<Vehicle>> GetAllByPageAsync(int page);
    }
}
