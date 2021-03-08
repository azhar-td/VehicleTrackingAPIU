using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleData.Models;
using VehicleData.Repositories.GenericRepo;

namespace VehicleData.Repositories.Interfaces
{
    public interface IVehiclePositionRepo:IGenericRepo<VehiclePosition>
    {
        Task<VehiclePosition> GetLatestByVehicleIdAsync(int vehcileid);
        Task<IEnumerable<VehiclePosition>> GetAllByVehicleIdAsync(int vehcileid);
        Task<VehiclePosition> GetByIdAsync(int id);
    }
}
