using System.ComponentModel.DataAnnotations;

namespace Registro.Models
{
    public class UsersModel
    {
        public int IdUsers { get; set; }

        [Required(ErrorMessage ="El campo Nombre es obligatorio")]
        public string? Name { get; set; }
        public string? Service { get; set; }
        public DateTime? Date { get; set; }
    }
}
