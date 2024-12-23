using api.Data;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using api.DTO.Admins;
using Microsoft.EntityFrameworkCore; // for the use of async


namespace api.Controllers
{
    [Route("api/admin")]   //This attribute defines the base route for this controller, meaning all routes in this controller will start with /api/admin.
    [ApiController]
    public class AdminController : ControllerBase
    { //This defines a new controller class named AdminController, which inherits from ControllerBase. This is a base class for controller classes in ASP.NET Core, offering common functionality like handling HTTP requests.
        private readonly ApplicationDbContext _context;  //This private field holds an instance of ApplicationDbContext, which is used to interact with the database. This dependency is injected into the controller’s constructor via constructor injection.
        public AdminController(ApplicationDbContext context)  //This is the constructor of the AdminController class. The parameter ApplicationDbContext context allows the controller to access the database context. The context object is assigned to the private field _context so that other methods within the controller can use it to perform database operations.
        {
            _context = context;
        }


        // http methodes starts from here
//right below is the synchronous way of writing the code.
        // [HttpGet("getAdmin")] // call the methode inside the route, inorder to include it in url
        //                       //https://api.example.com/api/admin/getAdmin
        // public IActionResult getAdmin()
        // { //When a client sends a request to https://api.example.com/api/admin/getAdmin, ASP.NET Core will intercept this request, route it to the AdminController, and then execute the getAdmin() method based on the [HttpGet] attribute.
        //     var admins = _context.Admins.ToList() //we are searching it in the database and then returning a list.
        //    .Select(s => s.ToAdminDto());


        //     return Ok(admins);
        // }

        //IAction is a object which return s stats codes etc


[HttpGet("getAdmin")]
public async Task<IActionResult> getAdmin()
{
    // Fetch the admins asynchronously from the database
    var admins = await _context.Admins
        .Select(s => s.ToAdminDto())
        .ToListAsync();

    return Ok(admins); // Return the result as an HTTP 200 response
}









        [HttpGet("{id}")]

        public IActionResult getAdminById([FromRoute] int id)
        {   // it extracts the id from the route, then puts it in the int id,
            var admin = _context.Admins.Find(id); // here we are finding the exact id in the database and returnig it
            if (admin == null)
            {
                return NotFound();  // the IActionResult will return it approprately
            }
            else
            {
                return Ok(admin.ToAdminDto()); // here we are directly calling the mapper
            }
        }



        //DTO=> data transfer object, used to remove unwanted datas before sending to the user

        [HttpPost("AddAdmin")]
        public IActionResult AddAdmin([FromBody] CreateAdminDtoRequest admin)// here we are taking data from the formbody,  which is then passed to dto to get only required data that is to be saved.
        {
            var Adm = admin.ToAdminFromCreateDto();
            //the below methodes are given in entity frmk
            _context.Admins.Add(Adm);
            _context.SaveChanges();

            var admins = _context.Admins.ToList()    // after saving we are retriving all the avaliable admins
             .Select(s => s.ToAdminDto());

            return Ok(admins);
        }


    }
}