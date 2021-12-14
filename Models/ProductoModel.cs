using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoWeb.Models
{
    public class ProductoModel
    {
        //[Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El codigo es obligatorio")]
        public int Codigo { get; set; }
        [Required(ErrorMessage = "La categoría es obligatoria")]
        public string Categoria { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "La cantidad es obligatoria")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "El precio es obligatorio")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public int Precio { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Fecha { get; set; }

        public string Imagen { get; set; }
    }
}
