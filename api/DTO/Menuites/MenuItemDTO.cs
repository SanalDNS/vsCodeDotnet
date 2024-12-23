namespace api.DTO.MenuItem
{
    public class MenuItemDTO
    {
        public string itemName { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public decimal price { get; set; } = 0.0m;

       public string CategoryName { get; set; }
    }
}