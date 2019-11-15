using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppAPI.Models;

namespace WebAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandItemsController : ControllerBase
    {
        private readonly ProjectContext _context;

        public BrandItemsController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/BrandItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandItem>>> GetBrandItems()
        {
            return await _context.BrandItems.ToListAsync();
        }

        // GET: api/BrandItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BrandItem>> GetBrandItem(int id)
        {
            var brandItem = await _context.BrandItems.FindAsync(id);

            if (brandItem == null)
            {
                return NotFound();
            }

            return brandItem;
        }

        // PUT: api/BrandItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrandItem(int id, BrandItem brandItem)
        {
            if (id != brandItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(brandItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BrandItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BrandItem>> PostBrandItem(BrandItem brandItem)
        {
            _context.BrandItems.Add(brandItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBrandItem", new { id = brandItem.Id }, brandItem);
        }

        // DELETE: api/BrandItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BrandItem>> DeleteBrandItem(int id)
        {
            var brandItem = await _context.BrandItems.FindAsync(id);
            if (brandItem == null)
            {
                return NotFound();
            }

            _context.BrandItems.Remove(brandItem);
            await _context.SaveChangesAsync();

            return brandItem;
        }

        private bool BrandItemExists(int id)
        {
            return _context.BrandItems.Any(e => e.Id == id);
        }
    }
}
