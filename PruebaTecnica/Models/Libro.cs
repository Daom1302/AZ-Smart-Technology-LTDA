using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class Libro
    {
        public int LibroID {  get; set; }

        [MinLength(2, ErrorMessage = "El título del libro debe tener al menos 2 caracteres.")]

        [Required(ErrorMessage = "El título del libro es obligatorio")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe seleccionar un autor")]
        public int autorId { get; set; }

        public Autor? Autor { get; set; }   

    }
}
