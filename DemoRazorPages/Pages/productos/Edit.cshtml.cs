using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemosMVC.Data;
using Domains.Entities;

namespace DemoRazorPages.Pages.productos
{
    public class EditModel : PageModel
    {
        private readonly DemosMVC.Data.TiendaDbContext _context;

        public EditModel(DemosMVC.Data.TiendaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Culture Culture { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Culture = await _context.Cultures.FirstOrDefaultAsync(m => m.CultureId == id);

            if (Culture == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Culture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CultureExists(Culture.CultureId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CultureExists(string id)
        {
            return _context.Cultures.Any(e => e.CultureId == id);
        }
    }
}
