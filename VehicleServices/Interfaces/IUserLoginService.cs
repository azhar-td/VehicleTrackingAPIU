using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleData.Models;

namespace VehicleServices.Interfaces
{
    public interface IUserLoginService
    {
        Task<IEnumerable<UserLogin>> GetAllByUserId(int userid);
        Task<UserLogin> GetLatestToken(int userId);
    }
}
