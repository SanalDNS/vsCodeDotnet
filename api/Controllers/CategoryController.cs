using api.Data;
using api.catMapper;
using Microsoft.AspNetCore.Mvc;
using api.DTO.Categorys;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/category")]   //This attribute defines the base route for this controller, meaning all routes in this controller will start with /api/admin.
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        // below are http methodes and routes


        [HttpGet("GetCategory")]

        public async Task<IActionResult> GetCategory()
        {
            try
            {
                var category = await _context.Categories.Select(s => s.TocategoryDTO()).ToListAsync();
                // the TocategoryDTO is a mapper methode in mapper folder.
                return Ok(category);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }

        }


        [HttpPost("AddCategory")]

        public async Task<IActionResult> AddCategory([FromBody] Category newCategor)
        {
            try
            {
                //[FromBody]: The [FromBody] attribute tells ASP.NET Core to take the data from the HTTP request body (usually in JSON format) and map it to the newAdmin parameter.
                //Category: This is the model (typically a database entity) that represents the structure of the data you are saving in the database. It’s directly related to your database table.
                //newCategor: This is the variable name for the instance of the Admin class that will hold the incoming data.
                _context.Categories.Add(newCategor);
                await _context.SaveChangesAsync();
                return Ok(new { Message = "Category added successfully", Category = newCategor });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }


        }


        [HttpDelete("DeleteCategory/{id}")]

        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var categ = await _context.Categories.FindAsync(id);
                _context.Categories.Remove(categ);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }



        }

    }
}