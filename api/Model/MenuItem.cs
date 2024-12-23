namespace api.Model{
    public class Menuitem{
        public int Id {get;set;}

        public string itemName {get;set;}=string.Empty;
        public string description {get;set;}=string.Empty;
        public decimal price {get;set;} = 0.0m;

         // Foreign key
        public int CategoryId { get; set; }

      // Navigation property (make it virtual for lazy loading)
        public virtual Category Category { get; set; }  // Mark this as virtual
    }
}