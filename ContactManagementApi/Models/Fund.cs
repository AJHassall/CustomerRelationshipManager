using System.ComponentModel.DataAnnotations;

namespace ContactManagementApi.Models
{
    public class Fund
    {
        [Key]
        public int FundId { get; set; }

        [Required]
        [MinLength(3)]
        public required string Name { get; set; }

    }
}