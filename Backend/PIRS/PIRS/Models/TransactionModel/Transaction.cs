using PIRS.Models.UserModel;

namespace PIRS.Models.TransactionModel
{
    public class Transaction
    {
        public int Id { get; set; }
        public double Payment { get; set; }
        public User? Company { get; set; }
        public User? Contractor { get; set; }
    }
}
