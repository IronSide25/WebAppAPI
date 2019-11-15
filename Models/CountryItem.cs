using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAPI.Models
{
    public class CountryItem
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Brand name is required")]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
/*
{
  "name": "Great Britain"
}
*/
