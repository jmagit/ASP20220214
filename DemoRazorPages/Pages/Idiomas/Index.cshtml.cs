using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Infraestructure.UoW;
using Domains.Entities;

namespace DemoRazorPages.Pages.Idiomas {
    public class IndexModel : PageModel
    {
        private readonly TiendaDbContext _context;

        public IndexModel(TiendaDbContext context)
        {
            _context = context;
        }

        public IList<Culture> Culture { get;set; }

        public async Task OnGetAsync()
        {
            Culture = await _context.Cultures.ToListAsync();
        }
    }
}
