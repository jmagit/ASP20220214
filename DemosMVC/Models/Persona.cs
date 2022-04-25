using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Util.Core.Validators;

namespace DemosMVC.Models {
    public class Persona {
        public int Id { get; set; }
        public string Nombre { set; get; }
        [MinLength(10)]
        public string Apellidos { set; get; }
        [NIF]
        [Display(Name ="N.I.F.")]
        public string Nif { set; get; }
        public bool Activo { set; get; }
        public DateTime FechaDeBaja { get; set; }

        public void Jubilate() {
            Activo = false;
            FechaDeBaja = DateTime.Now;
        }
    }
}
