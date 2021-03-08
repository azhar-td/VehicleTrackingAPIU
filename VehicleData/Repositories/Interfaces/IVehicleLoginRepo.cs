using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleData.Models;
using VehicleData.Repositories.GenericRepo;

namespace VehicleData.Repositories.Interfaces
{
    public interface IVehicleLoginRepo:IGenericRepo<VehicleLogin>
    {
        Task<IEnumerable<VehicleLogin>> GetAllByVehicleIdAsync(int vehicleId);
        Task<VehicleLogin> GetLatestByVehicleIdAsync(int vechileid);
    }
}
