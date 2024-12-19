namespace api.Model{
    public class Category{
        public int Id {get;set;}
        public string CategoryName {get;set;}=string.Empty;
 // Navigation property
        public List<Menuitem> Menuitems { get; set; } = new List<Menuitem>();

    }
}