using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleData.Repositories.Interfaces;

namespace VehicleData.Repositories.Wrapper
{
    public interface IRepoWrapper
    {
        IUserRepo UserRepo { get; }
        IUserLoginRepo UserLoginRepo { get; }
        IVehicleRepo VehicleRepo { get; }
        IVehicleLoginRepo VehicleLoginRepo { get; }
        IVehiclePositionRepo VehiclePositionRepo { get; }
        Task SaveAsync();
    }
}
