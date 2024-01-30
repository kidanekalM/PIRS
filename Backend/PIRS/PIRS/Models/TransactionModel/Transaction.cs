using System.ComponentModel.DataAnnotations;

namespace PIRS.Models.TransactionModel
{
    public class Transaction
    {
        [Key]
        public Guid Id { get; set; }
    }
}
