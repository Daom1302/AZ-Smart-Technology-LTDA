namespace PruebaTecnica.Models
{
    public class Autor
    {
        public int autorId { get; set; }
        public string? autorName { get; set; }

        public ICollection<Libro>? Libros { get; set; }
    }
}
