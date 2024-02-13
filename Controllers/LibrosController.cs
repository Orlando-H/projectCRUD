using Microsoft.AspNetCore.Mvc;
using proyectoCRUD.Data;
using proyectoCRUD.Models;
using System.Collections.Generic;

namespace proyectoCRUD.Controllers
{
    public class LibrosController : Controller
    {

        //Instanciamos el contexto
        private readonly AplicationDbContext _context;

        //Creamos el constructor
        public LibrosController(AplicationDbContext context) 
        {
            _context = context;


        }

        public IActionResult Index()
        {

            //Instanciamos la clase libros
            IEnumerable<Libro> listaLibros = _context.Libro;

            //Retorno de la lista
            return View(listaLibros);
        }

        //Creamos el metodo
        public IActionResult Create() {
            //Mostramos la vista
            return View();
        }

        //Creamos el metodo crear-post
        [HttpPost]

        public IActionResult Create(Libro libro) 
        { 
            if(ModelState.IsValid)
            {
                //Accederemos a la base de datos
                _context.Libro.Add(libro);

                //Guardamos los cambios
                _context.SaveChanges();

                //Indicamos con mensaje al usuario que el registro se ha guardado
                TempData["mensaje"] = "Registro Guardado Exitosamente!";

                //Redireccionamos el index
                return RedirectToAction("Index");
            }

            return View();

        }

        //Creamos el metodo para EDITAR
        public IActionResult Edit(int? id)
        {
            //Evaluamos si el registro es distinto de vacio
            if (id == null || id==0) {

                return NotFound();
            }

            //Obtener libro
            var libro = _context.Libro.Find(id);

            //Evaluamos el identificador
            if(libro == null)
            {
                //En caso de no encontrar el identificador
                return NotFound();
            }

            return View(libro);
        }

        //Metodo HTTP-POST-EDIT
        [HttpPost]

        public IActionResult Edit(Libro libro) { 

            if (ModelState.IsValid)
            {
                _context.Libro.Update(libro);

                _context.SaveChanges();

                TempData["mensaje"] = "EL REGISTRO SE HA ACTUALIZADO CORRECTAMENTE!";

                return RedirectToAction("Index");
            }
            return View();
        }


        //Creamos el metodo para ELIMINAR
        public IActionResult Delete(int? id)
        {
            //Evaluamos si el registro es distinto de vacio
            if (id == null || id == 0)
            {

                return NotFound();
            }

            //Obtener libro
            var libro = _context.Libro.Find(id);

            //Evaluamos el identificador
            if (libro == null)
            {
                //En caso de no encontrar el identificador
                return NotFound();
            }

            return View(libro);
        }

        //METODO HTTP-POST-DELETE
        [HttpPost]

        //Colocamos una validacion para el formulario
        [ValidateAntiForgeryToken]

        public IActionResult DeleteLibro(int? id) 
        {

            //Obtenemos el identificador del libro
            var libro = _context.Libro.Find(id);

            //Realizamos la validacion para el registro
            if (libro == null)
            {
                return NotFound();
            }

            //Realizamos la eliminacion del registro
            _context.Libro.Remove(libro);

            //Guardamos cambios
            _context.SaveChanges();

            TempData["mensaje"] = "EL REGISTRO HA SIDO ELIMINADO CORRECTAMENTE!";

            //Redireccionamos al Index
            return RedirectToAction("Index");
        }
    }
}
