using Domains.Contracts.DomainsServices;
using Domains.Contracts.Repositories;
using Domains.Entities;
using System;
using System.Collections.Generic;

namespace Domains.Services {
    public class ProductoService : IProductoService {
        IProductoRepository dao;

        public ProductoService(IProductoRepository dao) {
            this.dao = dao;
        }
        public Product add(Product item) {
            if (item.IsInvalid)
                throw new Exception("Error");
            return dao.add(item);
        }

        public void delete(Product item) {
            if (item.IsInvalid)
                throw new Exception("Error");
            dao.delete(item);
        }

        public void deleteById(int id) {
            dao.deleteById(id);
        }

        public List<Product> getAll() {
            return dao.getAll();
        }

        public List<Product> getAll(int page, int rows = 20) {
            return dao.getAll(page, rows);
        }

        public Product getOne(int id) {
            return dao.getOne(id);
        }

        public Product modify(Product item) {
            if (item.IsInvalid)
                throw new Exception("Error");
            return dao.modify(item);
        }

        // Métodos propios del dominio
    }
}
