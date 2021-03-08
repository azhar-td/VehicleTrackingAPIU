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
    public class UserRepo:GenericRepo<User>,IUserRepo
    {
        public UserRepo(VehicleTrackingContext vehicleTrackingContext)
        : base(vehicleTrackingContext)
        {
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await FindAll()
               .OrderBy(u => u.Name)
               .ToListAsync();
        }
        public async Task<User> GetByIdAsync(int userid)
        {
            return await FindByCondition(user => user.Id.Equals(userid))
            .FirstOrDefaultAsync();
        }
        public async Task<User> Authenticate(string email, string password)
        {
            return await FindByCondition(user => user.Email.Equals(email) && user.Password.Equals(password))
            .FirstOrDefaultAsync();
        }
    }
}
