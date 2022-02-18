using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Core.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Util.Core.Validators.Tests {
    class NIFAttributeMock : NIFAttribute {
        public ValidationResult test(object value, ValidationContext validationContext) {
            return base.IsValid(value, validationContext);
        }
    }

    [TestClass()]
    public class NIFAttributeTests {
        [TestMethod()]
        [DataRow("12345678z")]
        [DataRow("12345678Z")]
        [DataRow("1234S")]
        [DataRow(null)]
        public void NIFValido(String nif) {
            var t = new NIFAttributeMock();
            Assert.AreEqual(ValidationResult.Success, t.test(nif, null)); 
        }
        [TestMethod()]
        [DataRow("12345678")]
        [DataRow("Z")]
        [DataRow("1234J")]
        [DataRow("Z12345678")]
        [DataRow("")]
        public void NIFInvalido(String nif) {
            var t = new NIFAttributeMock();
            Assert.AreEqual("No es un NIF válido.", t.test(nif, null).ErrorMessage); ;
        }

        class Datos {
            [NIF("es una prueba")]
            public string Nif { get; set; }
        }
        [TestMethod()]
        public void ComoAtributoValido() {
            var validationResults = new List<ValidationResult>();
            var entidad = new Datos() { Nif = "12345678Z" };
            var context = new ValidationContext(entidad, null, null);

            Validator.TryValidateObject(entidad,
                      context,
                      validationResults,
                      true);

            Assert.AreEqual(0, validationResults.Count);
        }
        [TestMethod()]
        public void ComoAtributoInvalido() {
            var validationResults = new List<ValidationResult>();
            var entidad = new Datos() { Nif = "Z" };
            var context = new ValidationContext(entidad, null, null);

            Validator.TryValidateObject(entidad,
                      context,
                      validationResults,
                      true);

            Assert.AreEqual(1, validationResults.Count);
            Assert.AreEqual("es una prueba", validationResults[0].ErrorMessage);
        }

        // Ejemplos

        [TestMethod()]
        public void NoHacerAsi() {
            var t = new NIFAttributeMock();
            Assert.AreEqual(ValidationResult.Success, t.test("12345678Z", null));
            Assert.AreEqual(ValidationResult.Success, t.test("12345678z", null));
            Assert.AreEqual(ValidationResult.Success, t.test("1234S", null));
            Assert.AreEqual(ValidationResult.Success, t.test(null, null));
        }
        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void EjemploDeExcepcion() {
            // double i = 1; // Falla la prueba
            int i = 1; // Pasa la prueba
            i /= 0;
        }

    }
}