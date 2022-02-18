using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Entities.Tests {
    [TestClass()]
    public class ProductTests {

        #region Métodos específicos de la entidad
        [TestMethod()]
        [Timeout(10)]
        public void DescatalogarTest() {
            var p = new Product();
            p.Descatalogar();
            Assert.IsNotNull(p.DiscontinuedDate);
            Assert.IsTrue(DateTime.Now > p.DiscontinuedDate && p.DiscontinuedDate > DateTime.Now.AddSeconds(-1));
        }
        #endregion

        [TestMethod()]
        [Timeout(10)]
        public void DominiosValidosTest() {
            var p = new Product();
            Assert.IsTrue(p.IsValid);
        }
        [TestMethod()]
        [Timeout(10)]
        public void DominiosInvalidosTest() {
            var p = new Product();
            Assert.IsTrue(p.IsValid);
        }


    }
}