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
    public class UserLoginRepo : GenericRepo<UserLogin>, IUserLoginRepo
    {
        public UserLoginRepo(VehicleTrackingContext vehicleTrackingContext)
        : base(vehicleTrackingContext)
        {
        }
        public async Task<UserLogin> GetByIdAsync(int id)
        {
            return await FindByCondition(userlogin => userlogin.Id.Equals(id)).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<UserLogin>> GetAllByUserIdAsync(int userid)
        {
            return await FindByCondition(userlogin => userlogin.UserId.Equals(userid))
            .OrderByDescending(u=>u.CreationDT)
            .ToListAsync();
        }
        public async Task<UserLogin> GetLatestByUserIdAsync(int userid)
        {
            return await FindByCondition(userlogin => userlogin.UserId.Equals(userid))
            .OrderByDescending(u => u.CreationDT)
            .FirstOrDefaultAsync();
        }
    }
}
