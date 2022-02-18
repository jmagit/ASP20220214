using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemosMVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Repositories;
using Domains.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemosMVC.Controllers.Tests {
    [TestClass()]
    public class ProductosControllerTests {
        [TestMethod()]
        public void DetailsTest() {
            var dao = new ProductoRepositoryMock();
            var srv = new ProductoService(dao);
            var controler = new ProductosController(null, srv);

            var resp = controler.Details(1);

            Assert.IsNotNull(resp);

        }
    }
}