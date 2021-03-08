using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracking.DTO
{
    public class VMVehicleLogin
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public string Token { get; set; }
        public DateTime CreationDT { get; set; }
    }
}
