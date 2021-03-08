using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VehicleData.Models
{
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string RegNum { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime CreationDT { get; set; }
        public ICollection<VehiclePosition> VehiclePosition { get; set; }
        public ICollection<VehicleLogin> VehicleLogin { get; set; }
    }
}
