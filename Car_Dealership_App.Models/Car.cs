using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Dealership_App.Models
{
    public class Car
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int CTID { get; set; }
        
        public int Km { get; set; }

        public int Price { get; set; }

        public string? Color { get; set; }
        public bool Sold { get; set; }

        public DateTime ProductionDate { get; set; }
        public virtual CarType CarType { get; set; }

        [Required]
        public int DealerID { get; set; }

        public List<string> ImgUrls;

        public Car()
        {
            ImgUrls = new List<string>();
            //CarType = new CarType();
        }

        // Sample dataline:
        // 1#1#117067#2000#red#1999-10
        public Car(string line)
        {
            ImgUrls = new List<string>();
            string[] dataparts = line.Split('#');
            CTID = int.Parse(dataparts[0]);
            DealerID = int.Parse(dataparts[1]);
            Km = int.Parse(dataparts[2]);
            Price = int.Parse(dataparts[3]);
            Color = dataparts[4];
            ProductionDate = DateTime.Parse(dataparts[5]);
            Id = int.Parse(dataparts[6]);
            Sold = false;
            //CarType = new CarType();
        }
        
    }
}
