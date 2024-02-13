using System;
using System.ComponentModel.DataAnnotations;

namespace proyectoCRUD.Models
{
    public class Libro
    {
        //Propiedades

        [Key] //Permite establecer una llave primaria
        public int Id { get; set; }

        [Display(Name = "Titulo")]

        public string Titulo { get; set; }
            

        public string Descripcion { get; set; }
        [DataType(DataType.Date)] //Establecemos el formato fecha corta
        public DateTime FechaPublicacion { get; set; }

        [Required(ErrorMessage ="El nombre del autor es requerido")]

        public string Autor { get; set; }

        [Required(ErrorMessage = "El precio del libro es requerido")]

        public int PrecioLibro { get; set; }


        
        
    }
}
