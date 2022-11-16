using System.ComponentModel.DataAnnotations;

namespace CupsAndCakes.Models
{
    /// <summary>
    /// A email that will be sent to the support team of CupsAndCakes
    /// </summary>
    public class SupportEmail
    {
        /// <summary>
        /// The unique indentifier for each email id
        /// </summary>
        [Key]
        public int SupportId { get; set; }

        /// <summary>
        /// The subject of the email
        /// </summary>
        [Required]
        public string Subject { get; set; }

        /// <summary>
        /// The content of the email
        /// </summary>
        [Required]
        public string Content { get; set; }
    }
}
