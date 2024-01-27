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
        public ActionResult<Transaction>  Add(Transaction transaction)
        {   Transaction transact= _transactionRepository.add(transaction);
            return  Ok(transact);
        }
        
        
        [HttpGet]
        [Route("GetById/{id}")]
        public ActionResult<Transaction> GetById(int id)
        {
            return Ok( _transactionRepository.GetById(id));
        }
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<Transaction>> GetAll()
        {
            return Ok(_transactionRepository.GetAll());
        }
    }
}
