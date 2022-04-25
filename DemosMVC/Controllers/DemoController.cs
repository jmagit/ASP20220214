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
            var item = new Persona() { Id = 1, Nombre = "Pepito", Apellidos = "Grillo", Activo = true/*, FechaDeBaja = DateTime.Now*/ };
            // modelo 
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Saluda(Persona item) {
            if (ModelState.IsValid) {
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        public string cadena([FromHeader(Name ="accept-language")] string acceptLanguage) {
            // modelo 
                return "Hola Mundo " + acceptLanguage;
            
        }
        public IActionResult json() {
            // modelo 
            return Json(new Persona() { Id = 1, Nombre = "Pepito", Apellidos = "Grillo", Activo = true, FechaDeBaja = DateTime.Now });
        }

        public IActionResult estado([FromQuery] int id) {
            // modelo 
            return this.StatusCode(id);
        }


    }
}
