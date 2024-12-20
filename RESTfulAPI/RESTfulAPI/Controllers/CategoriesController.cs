namespace RESTfulAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using RESTfulAPI.Data;
    using RESTfulAPI.Entities;

    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _context.Categories
                                           .Include(c => c.SubCategories)
                                           .ToListAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory(Category category)
        {
            if (category.ParentCategoryId.HasValue)
            {
                var parentCategory = await _context.Categories.FindAsync(category.ParentCategoryId.Value);
                if (parentCategory == null)
                {
                    return BadRequest("Categoria pai não encontrada.");
                }
                category.ParentCategory = parentCategory;
            }

            var existingCategory = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == category.Id);
            if (existingCategory != null)
            {
                _context.Entry(existingCategory).State = EntityState.Detached;
                _context.Entry(category).State = EntityState.Modified;
            }
            else
            {
                _context.Categories.Add(category);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CategoryExists(category.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }


        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Category category)
        {
            if (id != category.Id) return BadRequest();
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return NotFound();
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
