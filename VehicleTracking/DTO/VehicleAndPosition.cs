using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracking.DTO
{
    public class VehicleAndPosition
    {
        public VMVehicle Vehicle { get; set; }
        public VMVehiclePosition VehiclePosition { get; set; }
        public List<VMVehiclePosition> PositionList { get; set; }
    }
}
