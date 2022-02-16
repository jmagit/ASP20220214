using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains.Entities;
namespace Domains.Contracts.Repositories {
    public interface IProductoRepository : IRepository<Product, int> {
        List<Product> getAll(int page = 0, int rows = 20);

    }
}
