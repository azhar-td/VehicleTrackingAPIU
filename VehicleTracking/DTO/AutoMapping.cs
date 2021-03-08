using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleData.Models;

namespace VehicleTracking.DTO
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<User, VMUser>(); // map from User to VMUser
            CreateMap<UserLogin, VMUserLogin>(); // map from UserLogin to VMUserLogin
            CreateMap<Vehicle, VMVehicle>(); // map from Vehicle to VMVehicle
            CreateMap<VehicleLogin, VMVehicleLogin>(); // map from VehicleLogin to VMVehicleLogin
            CreateMap<VehiclePosition, VMVehiclePosition>(); // map from VehiclePosition to VMVehiclePosition

            CreateMap<VMUser, User>(); // map from User to VMUser
            CreateMap<VMUserLogin, UserLogin>(); // map from UserLogin to VMUserLogin
            CreateMap<VMVehicle, Vehicle>(); // map from Vehicle to VMVehicle
            CreateMap<VMVehicleLogin, VehicleLogin>(); // map from VehicleLogin to VMVehicleLogin
            CreateMap<VMVehiclePosition, VehiclePosition>(); // map from VehiclePosition to VMVehiclePosition
        }
    }
}
