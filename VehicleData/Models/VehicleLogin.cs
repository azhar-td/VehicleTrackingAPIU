using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VehicleData.Models
{
    public class VehicleLogin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(Vehicle))]
        public int VehicleId { get; set; }
        [Required]
        public string Token { get; set; }
        [Required]
        public DateTime CreationDT { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
