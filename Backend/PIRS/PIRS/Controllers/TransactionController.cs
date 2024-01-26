using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PIRS.Models.TransactionModel;

namespace PIRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {  
        private readonly ITransactionRepository _transactionRepository;
        public TransactionController(ITransactionRepository transactionRepository) { 
           _transactionRepository= transactionRepository;
        }
        [HttpPut]
        public Transaction  Add(Transaction transaction)
        {
            return  _transactionRepository.add(transaction);
        }
        
        
        [HttpGet]
        [Route("GetById/{id}")]
        public Transaction GetById(int id)
        {
            return _transactionRepository.GetById(id);
        }
        [HttpGet]
        [Route("GetAll")]
        public List<Transaction> GetAll()
        {
            return _transactionRepository.GetAll();
        }
    }
}
