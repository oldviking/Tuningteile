using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuningteile.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(80, ErrorMessage = "Der Kategorie Name ist zu lang, maximal 80 Zeichen!")]
        [MinLength(1, ErrorMessage = "Der Name ist zu Kurz!")]
        [Required]
        public string Title { get; set; }

        public ICollection<TuningPart> TuningPart { get; set; }
    }
}
