using Microsoft.AspNetCore.Mvc;
using api.Model;
using api.Data;
using api.menuItemMapper;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;


namespace api.Controllers
{
    [Route("api/menuItems")]   //This attribute defines the base route for this controller, meaning all routes in this controller will start with /api/admin.
    [ApiController]
    public class MenuItemController : ControllerBase  //This defines the menuItemController class, which inherits from ControllerBase.
    //ControllerBase is the base class for API controllers in ASP.NET Core. It provides methods for handling HTTP requests and returning responses.
    //menuItemController will contain methods for handling requests related to menu items.
    {
        private readonly ApplicationDbContext _context;
        public MenuItemController(ApplicationDbContext context)
        //This is the constructor for the menuItemController class. It takes an ApplicationDbContext object as a parameter, which is passed into the constructor when the controller is instantiated.
        //This allows the controller to access the database context (_context) for operations like retrieving or saving data.
        {
            _context = context;
            //This assigns the passed-in context parameter to the class's _context field. This allows the controller to use _context to interact with the database within its methods.
        }



        // below are http methodes and routes


        [HttpGet("GetMenuItems")]

        public async Task<IActionResult> GetMenuItems()
        {
            try
            {
                var menuItem = await _context.Menuitems.Select(s => s.ToMenuItemDTO()).ToListAsync();
                // the TocategoryDTO is a mapper methode in mapper folder.
                return Ok(menuItem);
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }



        [HttpPost("AddMenuItems")]
        public async Task<IActionResult> AddMenuItems([FromBody] Menuitem newMenuitem)
        {
            try
            {
                var category = await _context.Categories
                                                  .FirstOrDefaultAsync(c => c.CategoryName == (newMenuitem.Category != null ? newMenuitem.Category.CategoryName : null));
                // the category is loaded to this using the lazyload of framework., database model has to be update to virtual
                newMenuitem.CategoryId = category.Id;
                newMenuitem.Category = null;   // this is added because , it wont update the category again,  as in this case the categry is previously added.
                _context.Menuitems.Add(newMenuitem);
                await _context.SaveChangesAsync();
                return Ok(new { Message = "Item added successfully", Menuitem = newMenuitem });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }




        [HttpPost("GetItemsInCatg/{id}")]
        public async Task<IActionResult> GetItemsInCatg(int id)
        {
            try
            {
                var items = await _context.Menuitems.Where(item => item.CategoryId == id).ToListAsync();
                return Ok(items);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }


        }







        [HttpDelete("DeleteMenuItem/{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {

            try
            {
                var item = await _context.Menuitems.FindAsync(id);
                _context.Menuitems.Remove(item);
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