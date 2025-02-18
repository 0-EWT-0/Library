using System.ComponentModel.DataAnnotations;

namespace Library.Models.Domain
{
    public class Rol
    {
        [Key]
        public int Pk_rol_id { get; set; }
        public string Pk_rol_name { get; set; } = string.Empty;
    }
}
