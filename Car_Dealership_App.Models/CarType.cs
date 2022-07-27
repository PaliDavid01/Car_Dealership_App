using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Dealership_App.Models
{
    public enum Fuel { Gas, Diesel, Electric, NaturalGas, Hydrogen}
    public class CarType
    {
        
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CTID { get; set; }

        [Required]
        public string? Brand { get; set; }

        [Required]
        public string? Type { get; set; }

        public int EngineCCM { get; set; }
        public int HorsePower { get; set; }

        [Required]
        public string? Fuel { get; set; }

        public CarType()
        {
            
        }
        // Sample dataline:
        // 1#Mercedes#CLS-200D#Diesel#1998#180
        public CarType(string line)
        {
            string[] dataparts = line.Split('#');
            CTID = int.Parse(dataparts[0]);
            Brand = dataparts[1];
            Type = dataparts[2];
            Fuel = dataparts[3];
            EngineCCM = int.Parse(dataparts[4]);
            HorsePower = int.Parse(dataparts[5]);
        }
    }
}
