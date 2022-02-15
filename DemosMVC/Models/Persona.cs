using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemosMVC.Models {
    public class Persona {
        public int Id { get; set; }
        public string Nombre { set; get; }
        public string Apellidos { set; get; }
        public bool Activo { set; get; }
        public DateTime FechaDeBaja { get; set; }

        public void Jubilate() {
            Activo = false;
            FechaDeBaja = DateTime.Now;
        }
    }
}
