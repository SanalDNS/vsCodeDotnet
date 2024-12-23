using api.Data;
using api.catMapper;
using Microsoft.AspNetCore.Mvc;
using api.DTO.Categorys;
using api.Model;

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


        [HttpGet("getCategory")]

        public IActionResult getCategory()
        {
            var category = _context.Categories.ToList().Select(s => s.TocategoryDTO());
            // the TocategoryDTO is a mapper methode in mapper folder.
            return Ok(category);
        }


        [HttpPost("AddCategory")]

        public IActionResult AddCategory([FromBody] Category newCategor)
        {
            //[FromBody]: The [FromBody] attribute tells ASP.NET Core to take the data from the HTTP request body (usually in JSON format) and map it to the newAdmin parameter.
            //Category: This is the model (typically a database entity) that represents the structure of the data you are saving in the database. It’s directly related to your database table.
            //newCategor: This is the variable name for the instance of the Admin class that will hold the incoming data.
            _context.Categories.Add(newCategor);
            _context.SaveChanges();
             return Ok(new { Message = "Category added successfully", Category = newCategor });
        }

    }
}