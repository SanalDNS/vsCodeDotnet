using api.Data;
using api.catMapper;
using Microsoft.AspNetCore.Mvc;
using api.DTO.Categorys;

namespace api.Controllers{
    public class CategoryController:ControllerBase{
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context){
            _context=context;
        }
// below are http methodes and routes


[HttpGet ("getCategory")]

public IActionResult getCategory(){
    var category=_context.Categories.ToList().Select(s => s.TocategoryDTO());
// the TocategoryDTO is a mapper methode in mapper folder.
    return Ok(category);
}



    }
}