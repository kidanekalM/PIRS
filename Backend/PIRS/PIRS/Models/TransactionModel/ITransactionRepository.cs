namespace PIRS.Models.TransactionModel
{
    public interface ITransactionRepository
    {
        public Transaction add();
        public Transaction edit(Transaction transaction);
        public Transaction delete(int id);
        public List<Transaction> GetAll();
    }
}
