using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Contracts.Repositories {
    public interface IRepository<E, K> {
        List<E> getAll();
        E getOne(K id);
        E add(E item);
        E modify(E item);
        void delete(E item);
        void deleteById(K id);
    }
}
