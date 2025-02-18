using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models.Domain
{
    public class User
    {
        [Key]
        public int Pk_user_id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string User_name { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [ForeignKey("Rol")]
        public int Fk_rol_id { get; set; }
        public Rol Rol { get; set; }    
    }
}
