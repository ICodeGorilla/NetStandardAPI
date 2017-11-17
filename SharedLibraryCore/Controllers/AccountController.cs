using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Contract;
using Service.DTO;

namespace SharedLibraryCore.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        /// <summary>
        /// Get all accounts, do not include account contacts
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allAccounts = _service.GetAll().ToList();
            if (allAccounts.Any())
            {
                return Ok(allAccounts);
            }
            return NotFound();
        }

        /// <summary>
        /// Get account by Id, includes contact
        /// </summary>
        /// <param name="id">Account Id</param>     
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var account = _service.GetById(id);
            if (account != null)
                return Ok(account);
            return NotFound();
        }

        /// <summary>
        /// Post account, will update or create account based on Id
        /// </summary>
        /// <param name="value">Account DTO</param>   
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AccountDto value)
        {
            ServiceResponse<AccountDto> response = _service.Save(value);
            if (response.Success)
                return Ok(response.Value);
            return BadRequest();
        }

        /// <summary>
        /// Delete account by Id
        /// </summary>
        /// <param name="id">Id of account</param>     
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = _service.Delete(id);
            if (response.Success)
                return Ok();
            return BadRequest();
        }
    }
}
