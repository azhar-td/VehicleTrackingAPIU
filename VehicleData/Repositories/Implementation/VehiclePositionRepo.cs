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
    public class VehiclePositionRepo: GenericRepo<VehiclePosition>, IVehiclePositionRepo
    {
        public VehiclePositionRepo(VehicleTrackingContext vehicleTrackingContext)
        : base(vehicleTrackingContext)
        {
        }
        public async Task<VehiclePosition> GetByIdAsync(int id)
        {
            return await FindByCondition(vehicleposition => vehicleposition.Id.Equals(id)).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<VehiclePosition>> GetAllByVehicleIdAsync(int vehcileid)
        {
            return await FindByCondition(vehicleposition => vehicleposition.VehicleId.Equals(vehcileid))
            .OrderByDescending(u => u.TimeStamp)
            .ToListAsync();
        }
        public async Task<VehiclePosition> GetLatestByVehicleIdAsync(int vehcileid)
        {
            return await FindByCondition(vehicleposition => vehicleposition.VehicleId.Equals(vehcileid))
            .OrderByDescending(u => u.TimeStamp)
            .FirstOrDefaultAsync();
        }
    }
}
