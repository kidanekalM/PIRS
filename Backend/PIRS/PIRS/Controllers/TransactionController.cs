using Microsoft.AspNetCore.Http;
using PIRS.Models.TransactionModel;
using Microsoft.AspNetCore.Identity;
using PIRS.Models.UserModel;
using PIRS.Models.ReportModel;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ChapaNET;

namespace PIRS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IReportRepository _reportRepository;

        public TransactionController(ITransactionRepository transactionRepository, UserManager<AppUser> userManager, IReportRepository reportRepository)
        {
            _transactionRepository = transactionRepository;
            _userManager = userManager;
            _reportRepository = reportRepository;
        }
        
        [HttpPost]
        public async Task<ActionResult<TransactionDto>> Add(TransactionDto transactionDto)
        {
            AppUser company = await _userManager.FindByIdAsync(transactionDto.CompanyId);
            var contractor = await _userManager.FindByIdAsync(transactionDto.ContractorId);
            var report = _reportRepository.GetById(transactionDto.ReportId);

            var transaction = new Transaction
            {
                Id = transactionDto.Id,
                Payment = transactionDto.Payment,
                DateTime = transactionDto.DateTime,
                Company = company,
                Contractor = contractor,
                Report = report
            };

            var transact = _transactionRepository.add(transaction);
            /*
            var chapaTransaction = new
            {
                amount = transactionDto.Payment,
                currency = "ETB", 
                email = contractor.Email,
                first_name = contractor.FirstName, 
                last_name = contractor.LastName, 
                phone_number = contractor.PhoneNumber, 
                tx_ref = transactionDto.Id.ToString(), 
                callback_url = "https://localhost:7077/swagger/index.html", 
                return_url = "https://localhost:7077/swagger/index.html"
            };

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "CHASECK_TEST-DDPjhSKiRFaBHM5cy1nrtSGeuMP0HgFC"); 
            var response = await client.PostAsJsonAsync("https://api.chapa.co/v1/transaction/initialize", chapaTransaction);
            var content = await response.Content.ReadAsStringAsync();
            var chapaResponse = JsonConvert.DeserializeObject<dynamic>(content);

            if (response.IsSuccessStatusCode)
            {
                var returnUrl = chapaResponse.data.authorization_url;
                return Ok(new { Transaction = transact, ReturnUrl = returnUrl });
            }
            else
            {
                return BadRequest(response);
            }*/
            return Ok(transact);
        }
        /*
        [HttpPost]
        public async Task<ActionResult<TransactionDto>> Add(TransactionDto transactionDto)
        {
            AppUser company = await _userManager.FindByIdAsync(transactionDto.CompanyId);
            var contractor = await _userManager.FindByIdAsync(transactionDto.ContractorId);
            var report = _reportRepository.GetById(transactionDto.ReportId);

            var transaction = new Transaction
            {
                Id = transactionDto.Id,
                Payment = transactionDto.Payment,
                DateTime = transactionDto.DateTime,
                Company = company,
                Contractor = contractor,
                Report = report
            };
            var transact = _transactionRepository.add(transaction);
            Chapa chapa = new("CHASECK_TEST-DDPjhSKiRFaBHM5cy1nrtSGeuMP0HgFC"); 

            var ID = Chapa.GetUniqueRef();

            var Request = new ChapaRequest(
                amount: transactionDto.Payment,
                email: contractor.Email, 
                firstName: contractor.FirstName, 
                lastName: contractor.LastName, 
                tx_ref: ID,
                callback_url: "https://localhost:7077/swagger/index.html" 
            );
            var Result = await chapa.RequestAsync(Request);
            return Ok(new { Transaction = transact, CheckoutUrl = Result.CheckoutUrl });
        }
        */
        [HttpGet]
        [Route("GetById/{id}")]
        public ActionResult<TransactionDto> GetById(int id)
        {
            var transaction = _transactionRepository.GetById(id);
            var transactionDto = new TransactionDto
            {
                Id = transaction.Id,
                Payment = transaction.Payment,
                DateTime = transaction.DateTime,
                CompanyId = transaction.Company?.Id,
                ContractorId = transaction.Contractor?.Id,
                ReportId = transaction.Report.ReportId
            };

            return Ok(transactionDto);
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<TransactionDto>> GetAll()
        {
            var transactions = _transactionRepository.GetAll();
            var transactionDtos = transactions.Select(t => new TransactionDto
            {
                Id = t.Id,
                Payment = t.Payment,
                DateTime = t.DateTime,
                CompanyId = t.Company?.Id,
                ContractorId = t.Contractor?.Id,
                ReportId = t.Report.ReportId
            }).ToList();

            return Ok(transactionDtos);
        }
        [HttpGet]
        [Route("GetAllByContractor/{contractorId}")]
        public ActionResult<List<TransactionDto>> GetAllByContractor(string contractorId)
        {
            var transactions = _transactionRepository.GetAll().Where(t => t.Contractor?.Id == contractorId);
            var transactionDtos = transactions.Select(t => new TransactionDto
            {
                Id = t.Id,
                Payment = t.Payment,
                DateTime = t.DateTime,
                CompanyId = t.Company?.Id,
                ContractorId = t.Contractor?.Id,
                ReportId = t.Report.ReportId
            }).ToList();

            return Ok(transactionDtos);
        }

        [HttpGet]
        [Route("GetAllByCompany/{companyId}")]
        public ActionResult<List<TransactionDto>> GetAllByCompany(string companyId)
        {
            var transactions = _transactionRepository.GetAll().Where(t => t.Company?.Id == companyId);
            var transactionDtos = transactions.Select(t => new TransactionDto
            {
                Id = t.Id,
                Payment = t.Payment,
                DateTime = t.DateTime,
                CompanyId = t.Company?.Id,
                ContractorId = t.Contractor?.Id,
                ReportId = t.Report.ReportId
            }).ToList();

            return Ok(transactionDtos);
        }
    }
}