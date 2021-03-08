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
    public class VehicleRepo : GenericRepo<Vehicle>, IVehicleRepo
    {
        public VehicleRepo(VehicleTrackingContext vehicleTrackingContext)
        : base(vehicleTrackingContext)
        {
        }
        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            return await FindAll()
               .OrderBy(u => u.RegNum)
               .ToListAsync();
        }
        public async Task<Vehicle> GetByIdAsync(int id)
        {
            return await FindByCondition(vehicle => vehicle.Id.Equals(id)).FirstOrDefaultAsync();
        }
        public async Task<Vehicle> GetByRegNumAsync(string reg)
        {
            return await FindByCondition(vehicle => vehicle.RegNum.Equals(reg)).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Vehicle>> GetAllByModelAsync(string model)
        {
            return await FindByCondition(vehicle => vehicle.Model.Equals(model))
                .OrderBy(v=>v.RegNum)
                .ToListAsync();
        }
        public async Task<Vehicle> Authenticate(string reg, string password)
        {
            return await FindByCondition(vehicle => vehicle.RegNum.Equals(reg) && vehicle.Password.Equals(password))
            .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Vehicle>> GetAllByPageAsync(int page)
        {
            return await FindAll()
                .Skip((page-1)*10)
                .Take(10)
               .OrderBy(u => u.RegNum)
               .ToListAsync();
        }
    }
}
