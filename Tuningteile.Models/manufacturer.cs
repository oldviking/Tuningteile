using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuningteile.Models
{
    public class manufacturer
    {
        public int Id { get; set; }

        [MaxLength(80, ErrorMessage = "Name is to long!")]
        [MinLength(1,ErrorMessage = "Name is to Short!")]
        [Required]
        public string Name { get; set; }

        public ICollection<Model> Model { get; set; }
    }
}
