namespace PruebaTecnica.Models
{
    public class Libro
    {
        public int LibroID {  get; set; }
        public string Titulo { get; set; } = string.Empty;
        public int autorId { get; set; }

        public Autor? Autor { get; set; }   

    }
}
