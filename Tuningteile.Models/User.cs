using System;
using System.ComponentModel.DataAnnotations;

namespace Tuningteile.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(1, ErrorMessage = "Firstname is to Short!")]
        public string Firstname { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(1, ErrorMessage = "Lastname is to Short!")]
        public string Lastname { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(1, ErrorMessage = "Username is to Short!")]
        public string Username { get; set; }
        [Required]
        [MaxLength(800)]
        public string Password { get; set; }
        [MaxLength(500)]
        public string salt { get; set; }
    }
}
