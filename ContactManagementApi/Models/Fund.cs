using System.ComponentModel.DataAnnotations;
using ContactManagementApi.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactManagementApi.Models
{
    public class Fund
    {
        [Key]
        public int FundId { get; private set;}

        [Required]
        [MinLength(3)]
        public required string Name { get; set; }



    }
}