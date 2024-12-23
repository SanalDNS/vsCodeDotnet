using System.Text.Json.Serialization;

namespace api.Model{
    public class Category{
        public int Id {get;set;}
        public string CategoryName {get;set;}=string.Empty;
 // Navigation property
  [JsonIgnore]
  public virtual List<Menuitem> Menuitems { get; set; } = new List<Menuitem>();  // Mark this as virtual

    }
}