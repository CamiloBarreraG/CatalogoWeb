using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoWeb.Models
{
    public class HomeModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Usuario es obligatorio")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }
        
    }
}
