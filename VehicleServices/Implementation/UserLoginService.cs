using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleData.Models;
using VehicleData.Repositories.Wrapper;
using VehicleServices.Interfaces;

namespace VehicleServices.Implementation
{
    public class UserLoginService:IUserLoginService
    {
        readonly private IRepoWrapper _repoWrapper;
        public UserLoginService(IRepoWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        public async Task<IEnumerable<UserLogin>> GetAllByUserId(int userid)
        {
            return await _repoWrapper.UserLoginRepo.GetAllByUserIdAsync(userid);
        }
        public async Task<UserLogin> GetLatestToken(int userId)
        {
            return await _repoWrapper.UserLoginRepo.GetLatestByUserIdAsync(userId);
        }
    }
}
