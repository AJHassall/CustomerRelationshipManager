using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactManagementApi.Models
{
    public class FundRelationship
    {
        [Key]
        public int ContactFundAssignmentId { get; private set; }

        [Required]
        public int ContactId { get; set; }

        [Required]
        public int FundId { get; set; }

        [ForeignKey("ContactId")]
        public Contact Contact { get; set; }

        [ForeignKey("FundId")]
        public Fund Fund { get; set; }
    }
}