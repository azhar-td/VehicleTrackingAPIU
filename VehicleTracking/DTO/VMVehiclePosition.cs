using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleTracking.DTO
{
    public class VMVehiclePosition
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        [Required]
        public decimal Longitude { get; set; }
        [Required]
        public decimal Latitude { get; set; }
        public DateTime TimeStamp { get; set; }
        [Required]
        public string RegNum { get; set; }
    }
}
