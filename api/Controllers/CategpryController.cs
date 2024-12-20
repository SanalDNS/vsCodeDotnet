// using api.Data;
// using Microsoft.AspNetCore.Mvc;

// namespace api.Controllers{
//     public class CategoryController:ControllerBase{
//         private readonly ApplicationDbContext _context;

//         public CategoryController(ApplicationDbContext context){
//             _context=context;
//         }
// // below are http methodes and routes


// [HttpGet ("getCategory")]

// public IActionResult getCategory(){
//     var category=_context.Categories.ToList().Select(s => s.ToCategoryDto());

//     return Ok(category);
// }



//     }
// }