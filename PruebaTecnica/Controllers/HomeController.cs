using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Models;
using PruebaTecnica.Data; 
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PruebaTecnica.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }
        //Mostrar los libros
        public IActionResult Index()
        {
            var Libros = _db.Libros.Include(l => l.Autor).ToList();
            return View(Libros);
        }
        //Agregar libro 
        public IActionResult AgregarLibro()
        {
            ViewBag.Autores = new SelectList(_db.Autores.ToList(), "autorId", "autorName");
            return View();
        }


        [HttpPost]
        public IActionResult AgregarLibro(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _db.Libros.Add(libro);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Si el modelo no es válido, recargar autores para el select.
            // ViewBag.Autores = new SelectList(_db.Autores, "autorId", "autorName");
            ViewBag.Autores = new SelectList(_db.Autores, "autorId", "autorName", libro.autorId);
            return View(libro);
        }


        //Agregar nuevo autor 
        public IActionResult AgregarAutor()
        {
            ViewBag.Autores = _db.Autores.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AgregarAutor(Autor autor)
        {
            if (ModelState.IsValid)
            {

                _db.Autores.Add(autor);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(autor);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
