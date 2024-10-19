using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class Autor
    {
        public int autorId { get; set; }

        [MinLength(2, ErrorMessage = "El nombre del autor debe tener al menos 2 caracteres.")]

        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "El autor solo puede contener letras.")]
        [Required(ErrorMessage = "El nombre del autor es obligatorio")]
        public string? autorName { get; set; }

        public ICollection<Libro>? Libros { get; set; }
    }
}
