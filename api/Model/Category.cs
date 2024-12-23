using System.Text.Json.Serialization;

namespace api.Model{
    public class Category{
        public int Id {get;set;}
        public string CategoryName {get;set;}=string.Empty;
 // Navigation property
  [JsonIgnore]
        public List<Menuitem> Menuitems { get; set; } = new List<Menuitem>();

    }
}