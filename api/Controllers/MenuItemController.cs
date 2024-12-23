using Microsoft.AspNetCore.Mvc;
using api.Model;
using api.Data;
using api.menuItemMapper;
using Microsoft.EntityFrameworkCore;


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

        public IActionResult GetMenuItems()
        {
            var menuItem = _context.Menuitems.ToList().Select(s => s.ToMenuItemDTO());
            // the TocategoryDTO is a mapper methode in mapper folder.
            return Ok(menuItem);

            // var menuItem = _context.Menuitems.ToList();
            // return Ok(menuItem);
        }



        [HttpPost("AddMenuItems")]
        public IActionResult AddMenuItems([FromBody] Menuitem newMenuitem)
        {

            var category = _context.Categories
                                      .FirstOrDefault(c => c.CategoryName == (newMenuitem.Category != null ? newMenuitem.Category.CategoryName : null));

            newMenuitem.CategoryId = category.Id;
             newMenuitem.Category = null; 
            _context.Menuitems.Add(newMenuitem);
            _context.SaveChanges();
            return Ok(new { Message = "Item added successfully", Menuitem = newMenuitem });
        }

    }
}