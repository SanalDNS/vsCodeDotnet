using Microsoft.AspNetCore.Mvc;

namespace api.Controllers{
 [Route("api/menuItems")]   //This attribute defines the base route for this controller, meaning all routes in this controller will start with /api/admin.
    [ApiController]
    public class menuItemController:ControllerBase{
        
    }
}