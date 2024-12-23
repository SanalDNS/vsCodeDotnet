using api.DTO.MenuItem;  //importing namespace of corrsponding DTO
using api.Model;  // importin database;

namespace api.menuItemMapper
{
    public static class MenuMapper
    {
        public static MenuItemDTO ToMenuItemDTO(this Menuitem menuitemInstance)
        {
            return new MenuItemDTO
            {
                itemName = menuitemInstance.itemName,
                description = menuitemInstance.description,
                price = menuitemInstance.price,
                CategoryName = menuitemInstance.Category.CategoryName  //this is done because we are using the navigation property to category model from menumodel
            };
        }
    }
}