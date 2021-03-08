using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleData.Models;
using VehicleData.Repositories.Implementation;
using VehicleData.Repositories.Interfaces;

namespace VehicleData.Repositories.Wrapper
{
    public class RepoWrapper:IRepoWrapper
    {
        private VehicleTrackingContext _vehicleTrackingContext;
        private IUserRepo _userRepo;
        private IUserLoginRepo _userLoginRepo;
        private IVehicleRepo _vehicleRepo;
        private IVehicleLoginRepo _vehicleLoginRepo;
        private IVehiclePositionRepo _vehiclePositionRepo;
        public RepoWrapper(VehicleTrackingContext vehicleTrackingContext)
        {
            _vehicleTrackingContext = vehicleTrackingContext;
        }
        public IUserRepo UserRepo
        {
            get
            {
                if (_userRepo == null)
                {
                    _userRepo = new UserRepo(_vehicleTrackingContext);
                }
                return _userRepo;
            }
        }
        public IUserLoginRepo UserLoginRepo
        {
            get
            {
                if (_userLoginRepo == null)
                {
                    _userLoginRepo = new UserLoginRepo(_vehicleTrackingContext);
                }
                return _userLoginRepo;
            }
        }
        public IVehicleRepo VehicleRepo
        {
            get
            {
                if (_vehicleRepo == null)
                {
                    _vehicleRepo = new VehicleRepo(_vehicleTrackingContext);
                }
                return _vehicleRepo;
            }
        }
        public IVehicleLoginRepo VehicleLoginRepo
        {
            get
            {
                if (_vehicleLoginRepo == null)
                {
                    _vehicleLoginRepo = new VehicleLoginRepo(_vehicleTrackingContext);
                }
                return _vehicleLoginRepo;
            }
        }
        public IVehiclePositionRepo VehiclePositionRepo
        {
            get
            {
                if (_vehiclePositionRepo == null)
                {
                    _vehiclePositionRepo = new VehiclePositionRepo(_vehicleTrackingContext);
                }
                return _vehiclePositionRepo;
            }
        }
        public async Task SaveAsync()
        {
            await _vehicleTrackingContext.SaveChangesAsync();
        }
    }
}
