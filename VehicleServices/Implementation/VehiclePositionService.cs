using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleData.Models;
using VehicleData.Repositories.Wrapper;
using VehicleServices.Interfaces;

namespace VehicleServices.Implementation
{
    public class VehiclePositionService: IVehiiclePositionService
    {
        readonly private IRepoWrapper _repoWrapper;
        public VehiclePositionService(IRepoWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        public async Task<VehiclePosition> GetCurrentLocationByVehicleIdAsync(int vehcileid)
        {
            return await _repoWrapper.VehiclePositionRepo.GetLatestByVehicleIdAsync(vehcileid);
        }
        public async Task<IEnumerable<VehiclePosition>> GetAllPositionsByVehicleIdAsync(int vehcileid)
        {
            return await _repoWrapper.VehiclePositionRepo.GetAllByVehicleIdAsync(vehcileid);
        }
        public async Task<VehiclePosition> GetByIdAsync(int id)
        {
            return await _repoWrapper.VehiclePositionRepo.GetByIdAsync(id);
        }
        public async Task VehiclePosition(VehiclePosition vehiclePosition)
        {
            _repoWrapper.VehiclePositionRepo.Create(vehiclePosition);
            await _repoWrapper.SaveAsync();
        }
    }
}
