using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemosMVC.Data;
using Domains.Contracts.Repositories;
using Domains.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemosMVC.Infraestructure {
    public class ProductoRepository : IProductoRepository {
        private readonly TiendaDbContext _context;

        public ProductoRepository(TiendaDbContext context) {
            _context = context;
        }


        public List<Product> getAll() {
            return _context.Products.ToList();
        }
        public List<Product> getAll(int page, int rows = 20) {
            return _context.Products.Where(item=>!item.DiscontinuedDate.HasValue).Skip(page * rows).Take(rows).ToList();

        }

        public Product getOne(int id) {
            return _context.Products
                .Include(p => p.ProductModel)
                .Include(p => p.ProductSubcategory)
                .Include(p => p.SizeUnitMeasureCodeNavigation)
                .Include(p => p.WeightUnitMeasureCodeNavigation)
                .FirstOrDefault(m => m.ProductId == id);
        }

        public Product add(Product item) {
            throw new NotImplementedException();
        }

        public void delete(Product item) {
            item.DiscontinuedDate = DateTime.Now;
            _context.Update(item);
             _context.SaveChanges();
        }

        public void deleteById(int id) {
            throw new NotImplementedException();
        }

        public Product modify(Product item) {
            throw new NotImplementedException();
        }
    }
    public class ProductoRepositoryMock : IProductoRepository {
        public List<Product> getAll() {
            List<Product> rslt = new List<Product>();
            rslt.Add(new Product() { ProductNumber = "uno", Name = "producto 1", ProductId = 1 });
            rslt.Add(new Product() { ProductNumber = "dos", Name = "producto 2", ProductId = 2 });
            rslt.Add(new Product() { ProductNumber = "tres", Name = "producto 3", ProductId = 3 });
            return rslt;
        }
        public List<Product> getAll(int page = 0, int rows = 20) {
            return getAll();

        }

        public Product getOne(int id) {
            return new Product() { ProductNumber = "demo", Name = "producto demo", ProductId = id };
        }

        public Product add(Product item) {
            throw new NotImplementedException();
        }

        public void delete(Product item) {
            throw new NotImplementedException();
        }

        public void deleteById(int id) {
            throw new NotImplementedException();
        }

        public Product modify(Product item) {
            throw new NotImplementedException();
        }
    }
}
