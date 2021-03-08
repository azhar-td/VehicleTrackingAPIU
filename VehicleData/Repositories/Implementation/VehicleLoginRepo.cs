using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleData.Models;
using VehicleData.Repositories.GenericRepo;
using VehicleData.Repositories.Interfaces;

namespace VehicleData.Repositories.Implementation
{
    public class VehicleLoginRepo:GenericRepo<VehicleLogin>, IVehicleLoginRepo
    {
        public VehicleLoginRepo(VehicleTrackingContext vehicleTrackingContext)
        : base(vehicleTrackingContext)
        {
        }
        public async Task<VehicleLogin> GetByIdAsync(int id)
        {
            return await FindByCondition(vehiclelogin => vehiclelogin.Id.Equals(id)).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<VehicleLogin>> GetAllByVehicleIdAsync(int vehcileid)
        {
            return await FindByCondition(vehiclelogin => vehiclelogin.VehicleId.Equals(vehcileid))
            .OrderByDescending(u => u.CreationDT)
            .ToListAsync();
        }
        public async Task<VehicleLogin> GetLatestByVehicleIdAsync(int vehcileid)
        {
            return await FindByCondition(vehiclelogin => vehiclelogin.VehicleId.Equals(vehcileid))
            .OrderByDescending(u => u.CreationDT)
            .FirstOrDefaultAsync();
        }
    }
}
