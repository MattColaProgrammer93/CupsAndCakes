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

        /// <summary>
        /// A instructor's first and last name
        /// </summary>
        public string FullName { get; set; }
    }
}
