using System.ComponentModel.DataAnnotations;

namespace ContactManagementApi.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [MinLength(3)]
        public required string Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }
    }
}