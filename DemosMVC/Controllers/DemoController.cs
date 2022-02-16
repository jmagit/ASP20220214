using DemosMVC.Data;
using DemosMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemosMVC.Controllers {
    public class DemoController : Controller {
        public IActionResult Index() {
            // modelo 
            ViewData["saluda"] = true;
            ViewData["nombre"] = "pepito";

            return View();
        }
        public IActionResult Saluda(int? id) {
            // modelo 
            return View(new Persona() { Id = 1, Nombre = "Pepito", Apellidos = "Grillo", Activo = true, FechaDeBaja = DateTime.Now });
        }
    }
}
