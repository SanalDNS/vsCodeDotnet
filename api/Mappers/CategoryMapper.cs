using api.DTO.Categorys;
using api.Model;

namespace api.catMapper{
    public static class CategoryMapper{
        public static categoryDTO TocategoryDTO(this Category categoryInstance){
            return new  categoryDTO{
                 CategoryName=categoryInstance.CategoryName
            };
        }
    }
}