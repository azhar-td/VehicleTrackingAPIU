using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleData.Models;
using VehicleData.Repositories.Wrapper;
using VehicleServices.Interfaces;

namespace VehicleServices.Implementation
{
    public class VehicleLoginService:IVehicleLoginService
    {
        readonly private IRepoWrapper _repoWrapper;
        public VehicleLoginService(IRepoWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        public async Task<IEnumerable<VehicleLogin>> GetAllByVehicleIdAsync(int vehicleId)
        {
            return await _repoWrapper.VehicleLoginRepo.GetAllByVehicleIdAsync(vehicleId);
        }
        public async Task<VehicleLogin> GetLatestToken(int vehicleId)
        {
            return await _repoWrapper.VehicleLoginRepo.GetLatestByVehicleIdAsync(vehicleId);
        }
    }
}
