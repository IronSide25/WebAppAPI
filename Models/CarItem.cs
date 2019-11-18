using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAPI.Models
{
    public class CarItem
    {
        [Key]
        public string VIN { get; set; }
        [Required(ErrorMessage = "Brand id is required")]
        public int? BrandID { get; set;  }
        [ForeignKey("BrandID")]
        public BrandItem Brand { get; set; }
        [StringLength(50)]
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public int Mileage { get; set; }
        [Required(ErrorMessage = "Fuel type is required")]
        public string Fuel { get; set; }//make dictionary and this must be a list/array. Or a type of gasoline/gas is needed
        public int EnginePower { get; set; }
        [StringLength(50)]
        public string Color { get; set; }
        public string Photo { get; set; }
        public float NetPrice { get; set; }
        [StringLength(5000)]
        public string Description { get; set; }
    }
}
/*
  {
  "vin": "123asd",
  "brandid":1,
  "model":"Cayenne",
  "productionyear":1994,
  "mileage": 12500,
  "fuel": "gasolinecc",
  "enginepower": 350,
  "color": "red",
  "photo": null,
  "description":"very niiice car, buyit pls"
}
*/
