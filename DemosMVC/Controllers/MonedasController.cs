using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infraestructure.UoW;
using Domains.Entities;
using System.ComponentModel.DataAnnotations;

namespace DemosMVC.Controllers {
    public partial class CurrencyDTO {
        [Required]
        //        [StringLength(3)]
        public string CurrencyCode { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class MonedasController : ControllerBase {
        private readonly TiendaDbContext _context;

        public MonedasController(TiendaDbContext context) {
            _context = context;
        }

        // GET: api/Monedas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurrencyDTO>>> GetCurrencies(int? page, int rows = 20) {
            if (page.HasValue)
                return await _context.Currencies.Skip(page.Value * rows).Take(rows).Select(c => new CurrencyDTO() {
                    CurrencyCode = c.CurrencyCode, Name = c.Name,
                    ModifiedDate = c.ModifiedDate
                }).ToListAsync();
            else
                return await _context.Currencies.Select(c => new CurrencyDTO() {
                    CurrencyCode = c.CurrencyCode, Name = c.Name,
                    ModifiedDate = c.ModifiedDate
                }).ToListAsync();
        }

        // GET: api/Monedas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CurrencyDTO>> GetCurrency(string id) {
            var currency = await _context.Currencies.Where(c => c.CurrencyCode == id).Select(c => new CurrencyDTO() {
                CurrencyCode = c.CurrencyCode, Name = c.Name,
                ModifiedDate = c.ModifiedDate
            }).FirstOrDefaultAsync();

            if (currency == null) {
                return NotFound();
            }

            return currency;
        }

        // POST: api/Monedas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CurrencyDTO>> PostCurrency(CurrencyDTO currency) {
            var item = new Currency() {
                CurrencyCode = currency.CurrencyCode, Name = currency.Name,
                ModifiedDate = currency.ModifiedDate
            };
            if (item.IsInvalid) {
                return this.BadRequest(ModelState);
            }
            _context.Currencies.Add(item);
            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateException) {
                if (CurrencyExists(currency.CurrencyCode)) {
                    return Conflict();
                } else {
                    throw;
                }
            }

            return CreatedAtAction("GetCurrency", new { id = currency.CurrencyCode }, item);
        }

        // PUT: api/Monedas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurrency(string id, CurrencyDTO currency) {
            if (id != currency.CurrencyCode) {
                return BadRequest();
            }

            var item = new Currency() {
                CurrencyCode = currency.CurrencyCode, Name = currency.Name,
                ModifiedDate = currency.ModifiedDate
            };
            _context.Entry(item).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!CurrencyExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Monedas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurrency(string id) {
            var currency = await _context.Currencies.FindAsync(id);
            if (currency == null) {
                return NotFound();
            }

            _context.Currencies.Remove(currency);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CurrencyExists(string id) {
            return _context.Currencies.Any(e => e.CurrencyCode == id);
        }
    }
}
