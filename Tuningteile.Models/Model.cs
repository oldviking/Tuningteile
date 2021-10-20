using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuningteile.Models
{
    public class Model
    {
        public int Id { get; set; }

        public int ManufacturerId { get; set; }

        [MaxLength(80, ErrorMessage = "Name is to Long!")]
        [MinLength(1, ErrorMessage = "Name is to Short!")]
        [Required]
        public string Title { get; set; }
        
        [MaxLength(4, ErrorMessage = "Year is to Long! Only 4 Characters!")]
        [Required]
        public string Begin_Year_construction { get; set; }
        [MaxLength(4, ErrorMessage = "Year is to Long! Only 4 Characters!")]
        [Required]
        public string End_Year_construction { get; set; }

        public ICollection<compatibility> compatibilities { get; set; }
        public manufacturer Manufacturer { get; set; }

        public string Name { get { return Manufacturer.Name + " " + Title; } }
    }
}
