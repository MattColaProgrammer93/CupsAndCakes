using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace CupsAndCakes.Models
{
    /// <summary>
    /// A simple order
    /// </summary>
    public class Order
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The name of the order
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The flavor of the order
        /// </summary>
        public string Flavor { get; set; }

        /// <summary>
        /// The type of order
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The number of orders
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The customer's order
        /// </summary>
        public Customer? Person { get; set; }
    }

    public class OrderCreateViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Flavor { get; set; }

        [Required]
        [Display(Name = "Cake or Cupcake")]
        public string Type { get; set; }

        [Required]
        [Range(1, 100)]
        public int Quantity { get; set; }

        public List<Customer>? AllPresentCustomers { get; set; }

        public int ChosenCustomer { get; set; }
    }

    public class OrderIndexViewModel
    {
        public int OrderId { get; set; }

        [Display(Name = "Order's Name")]
        public string OrderName { get; set; }

        [Display(Name = "Order's Flavor")]
        public string OrderFlavor { get; set; }

        [Display(Name = "Order Type")]
        public string OrderType { get; set; }

        [Display(Name = "Number of Orders")]
        public int OrderQuantity { get; set; }

        [Display(Name = "Customer")]
        public string CustomerName { get; set; }
    }
}
