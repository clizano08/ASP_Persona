using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona_EL
{
    public class Persona
    {
        [Display(Name = "Identificación")]
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime Nacimiento { get; set; }
        public String Edad { get; set; }
    }
}
