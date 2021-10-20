using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tuningteile.Models
{
    public class TuningPart
    {
        
        public int Id { get; set; }
        [MaxLength(80, ErrorMessage = "Name is to Long!")]
        [MinLength(1, ErrorMessage = "Name is to Short!")]
        
        public string ManufacturerName { get; set; }
        [Required]
        [MaxLength(80, ErrorMessage = "Name is to Long!")]
        [MinLength(1, ErrorMessage = "Name is to Short!")]
        public string PartName { get; set; }
        [Required]
        public decimal Price { get; set; }
        public bool available { get; set; }

        public int CategoryId { get; set; }
        public Category category { get; set; }
        public ICollection<compatibility> compatibilities { get; set; }


        public string Name { get
            {
                return ManufacturerName + " " + PartName;
            } 
        }


    }
}
