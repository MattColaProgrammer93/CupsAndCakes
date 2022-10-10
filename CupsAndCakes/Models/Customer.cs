using System.ComponentModel.DataAnnotations;

namespace CupsAndCakes.Models
{
    /// <summary>
    /// A individual customer
    /// </summary>
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }
    }
}
