using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.Contracts.DomainsServices {
    public interface IDomainPageableService<E, K>: IDomainService<E, K>, IPageableService<E> {
    }

    public interface IPageableService<E> {
        List<E> getPage(int page = 0, int rows = 20);
    }
}
