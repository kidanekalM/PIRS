namespace PIRS.Models.TransactionModel
{
    public interface ITransactionRepository
    {
        public Transaction add();
        public List<Transaction> GetAll();
        public Transaction GetById(int id);
    }
}
