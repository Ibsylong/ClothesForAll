using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClothesForAll.Data;

namespace ClothesForAll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothesTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public ClothesTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ClothesTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClothesType>>> GetClothesTypes()
        {
            return await _context.ClothesTypes.ToListAsync();
        }

        // GET: api/ClothesTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClothesType>> GetClothesType(int id)
        {
            var clothesType = await _context.ClothesTypes.FindAsync(id);

            if (clothesType == null)
            {
                return NotFound();
            }

            return clothesType;
        }

        // PUT: api/ClothesTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClothesType(int id, ClothesType clothesType)
        {
            if (id != clothesType.ClothesTypeId)
            {
                return BadRequest();
            }

            _context.Entry(clothesType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClothesTypeExists(id))
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

        // POST: api/ClothesTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ClothesType>> PostClothesType(ClothesType clothesType)
        {
            _context.ClothesTypes.Add(clothesType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClothesType", new { id = clothesType.ClothesTypeId }, clothesType);
        }

        // DELETE: api/ClothesTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClothesType>> DeleteClothesType(int id)
        {
            var clothesType = await _context.ClothesTypes.FindAsync(id);
            if (clothesType == null)
            {
                return NotFound();
            }

            _context.ClothesTypes.Remove(clothesType);
            await _context.SaveChangesAsync();

            return clothesType;
        }

        private bool ClothesTypeExists(int id)
        {
            return _context.ClothesTypes.Any(e => e.ClothesTypeId == id);
        }
    }
}
