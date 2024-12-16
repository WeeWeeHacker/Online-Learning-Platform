using System.ComponentModel.DataAnnotations;

namespace CacheClass.Models
{
    public class Account
    {
        public int Id { get; set; }  // Primary Key

        [Required]
        [StringLength(100)]
        public string Username { get; set; }
        
        public string Role { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public string PasswordHash { get; set; }
    }
}
