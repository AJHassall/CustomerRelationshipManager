using ContactManagementApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ContactManagementApi.Enums;
namespace ContactManagementApi.Data
{
    public class Trade
    {
        [Key]
        public int TradeId {get; set;}
        public TradeType tradeType;
        public decimal amount;

        [Required]
        public int FundId { get; set; }

        [Required]
        [ForeignKey("FundId")]
        public Fund Fund { get; set; }

        
    }
}
