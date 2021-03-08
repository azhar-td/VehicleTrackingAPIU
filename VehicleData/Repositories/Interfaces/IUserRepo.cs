using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleData.Models;
using VehicleData.Repositories.GenericRepo;

namespace VehicleData.Repositories.Interfaces
{
    public interface IUserRepo:IGenericRepo<User>
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> Authenticate(string email, string password);
    }
}
