using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Dealership_App.Models
{
    public class CarDealer
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DealerID { get; set; }

        public string? DealershipName { get; set; }

        [Required]
        [MaxLength(4)]
        public int PostalCode { get; set; }

        [Required]
        [StringLength(100)]
        public string? Street { get; set; }
        public string? City { get; set; }

        [Required,StringLength(100)]
        public int HouseNum { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

        public CarDealer()
        {
            Cars = new HashSet<Car>();
        }
        // Sample dataline:
        // 1#5600#Mike-Car#Mezőtúr#Puskin#109
        public CarDealer(string line)
        {
            Cars = new HashSet<Car>();
            string[] dataparts = line.Split('#');
            DealerID = int.Parse(dataparts[0]);
            DealershipName = dataparts[2];
            PostalCode = int.Parse(dataparts[1]);
            Street = dataparts[4];
            City = dataparts[3];
            HouseNum = int.Parse(dataparts[5]);
        }

    }
}
