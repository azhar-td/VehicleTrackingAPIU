using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleData.Models;
using VehicleData.Repositories.GenericRepo;

namespace VehicleData.Repositories.Interfaces
{
    public interface IVehicleRepo:IGenericRepo<Vehicle>
    {
        Task<IEnumerable<Vehicle>> GetAllAsync();
        Task<Vehicle> GetByIdAsync(int id);
        Task<Vehicle> GetByRegNumAsync(string reg);
        Task<IEnumerable<Vehicle>> GetAllByModelAsync(string model);
        Task<Vehicle> Authenticate(string reg, string password);
        Task<IEnumerable<Vehicle>> GetAllByPageAsync(int page);
    }
}
