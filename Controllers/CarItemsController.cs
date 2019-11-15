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
    public class CarItemsController : ControllerBase
    {
        private readonly ProjectContext _context;

        public CarItemsController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/CarItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarItem>>> GetCarItems()
        {
            //return await _context.CarItems.ToListAsync();
            return await _context.CarItems.Include(e => e.Brand).ToListAsync();
        }

        // GET: api/CarItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarItem>> GetCarItem(string id)
        {
            //var carItem = await _context.CarItems.FindAsync(id);
            var carItem = await _context.CarItems.Include(i => i.Brand).FirstOrDefaultAsync(i => i.VIN == id);

            if (carItem == null)
            {
                return NotFound();
            }

            return carItem;
        }

        // PUT: api/CarItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarItem(string id, CarItem carItem)
        {
            if (id != carItem.VIN)
            {
                return BadRequest();
            }
            _context.Entry(carItem).State = EntityState.Modified;
            if (carItem.Photo == null)
            {
                //var entity = _context.CarItems.FirstOrDefault(i => i.VIN == id);
                //carItem.Photo = entity.Photo;
                //_context.Entry(carItem.Photo).State = EntityState.Unchanged;
                _context.Entry(carItem).Property(x => x.Photo).IsModified = false;
            }
                      
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarItemExists(id))
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

        // POST: api/CarItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CarItem>> PostCarItem(CarItem carItem)
        {
            _context.CarItems.Add(carItem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CarItemExists(carItem.VIN))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCarItem", new { id = carItem.VIN }, carItem);
        }

        // DELETE: api/CarItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarItem>> DeleteCarItem(string id)
        {
            var carItem = await _context.CarItems.FindAsync(id);
            if (carItem == null)
            {
                return NotFound();
            }

            _context.CarItems.Remove(carItem);
            await _context.SaveChangesAsync();

            return carItem;
        }

        private bool CarItemExists(string id)
        {
            return _context.CarItems.Any(e => e.VIN == id);
        }
    }
}
