using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domains.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Domains.Contracts.Repositories;

namespace Domains.Services.Tests {
    [TestClass()]
    public class ProductoServiceTests {
        [TestMethod()]
        public void ProductoServiceTest() {
            Assert.Fail();
        }

        [TestMethod()]
        public void addTest() {
            Assert.Fail();
        }

        [TestMethod()]
        public void deleteTest() {
            Assert.Fail();
        }

        [TestMethod()]
        public void deleteByIdTest() {
            Assert.Fail();
        }

        [TestMethod()]
        public void getAllTest() {
            Assert.Fail();
        }

        [TestMethod()]
        public void getAllTest1() {
            Assert.Fail();
        }

        [TestMethod()]
        public void getOneTest() {
            var moq = new Mock<IProductoRepository>();
            moq.Setup(o => o.getOne(1)).Returns(new Entities.Product() { ProductId = 1 });

            var srv = new ProductoService(moq.Object);
            var item = srv.getOne(1);
            Assert.AreEqual(1, item.ProductId);
        }

        [TestMethod()]
        public void modifyTest() {
            Assert.Fail();
        }
    }
}