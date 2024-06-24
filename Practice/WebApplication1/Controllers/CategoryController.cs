using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Category.ToListAsync());
        }




        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _context.Category.AddAsync(category);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Create), category);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var existData = await _context.Category.FindAsync(id);

            if (existData is null)
            {
                return NotFound();
            }
            return Ok(existData);
        }

        [HttpDelete]

        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var existData = await _context.Category.FindAsync(id);

            if (existData is null)
            {
                return NotFound();
            }

            _context.Category.Remove(existData);

            await _context.SaveChangesAsync();

            return Ok(existData);
        }
    }
}
