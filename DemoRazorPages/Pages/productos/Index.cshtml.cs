using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DemosMVC.Data;
using Domains.Entities;

namespace DemoRazorPages.Pages.productos
{
    public class IndexModel : PageModel
    {
        private readonly DemosMVC.Data.TiendaDbContext _context;

        public IndexModel(DemosMVC.Data.TiendaDbContext context)
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
