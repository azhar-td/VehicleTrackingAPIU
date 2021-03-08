using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleData.Models;
using VehicleData.Repositories.GenericRepo;

namespace VehicleData.Repositories.Interfaces
{
    public interface IUserLoginRepo:IGenericRepo<UserLogin>
    {
        Task<IEnumerable<UserLogin>> GetAllByUserIdAsync(int userid);
        Task<UserLogin> GetLatestByUserIdAsync(int userid);
    }
}
