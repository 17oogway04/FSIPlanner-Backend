using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using fsiplanner_backend.Migrations;
using fsiplanner_backend.Models;
using fsiplanner_backend.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace fsiplanner_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BalanceController : ControllerBase
    {

        private readonly ILogger<BalanceController> _logger;

        private readonly IBalanceRepository _balanceRepository;
        private readonly FSIPlannerDbContext _context;

        public BalanceController(ILogger<BalanceController> logger, IBalanceRepository repository, FSIPlannerDbContext context)
        {
            _logger = logger;
            _balanceRepository = repository;
            _context = context;
        }
        // private static readonly Dictionary<string, int> _hashMap = new Dictionary<string, int>
        // {
        //     {"1", 0}, //Checking
        //     {"2", 0}, //Currency
        //     {"3", 0}, //Savings
        //     {"4", 0}, //CDs
        //     {"5", 0}, //Health and Medical Savings
        //     {"6", 0}, //Life Insurance
        //     {"7", 0}, //Annuities
        //     {"8", 0}, //Investments
        //     {"9", 0}, //IRAs
        //     {"10", 0}, //Roth IRA
        //     {"11", 0}, //Employer retirement plan
        //     {"12", 0}, //Bullion
        //     {"13", 0}, //Primary Residence
        //     {"14", 0}, //Secondary Residence
        //     {"15", 0}, //Real Estate
        //     {"16", 0}, //Business
        //     {"17", 0}, //Trust
        //     {"18", 0}, //Vehicles
        //     {"19", 0}, //Personal Property
        //     {"20", 0}, //Credit Cards
        //     {"21", 0}, //Student Loans
        //     {"22", 0} //Other
        // };

        [HttpGet("by-username/{username}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<IEnumerable<Balance>> GetBalancesByUsername(string username)
        {
            var balances = _balanceRepository.GetByUsername(username);
            if (balances == null || !balances.Any())
            {
                return NotFound();
            }
            return Ok(balances);
        }

        [HttpGet("by-balanceId/{balanceId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public ActionResult<Balance> GetByBalanceId(int balanceId)
        {
            var balances = _balanceRepository.GetById(balanceId);
            if (balances == null)
            {
                return NotFound();
            }
            return Ok(balances);
        }

        [HttpPut("{balanceId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Balance> UpdateBalances(Balance balance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(_balanceRepository.Update(balance));
        }

        [HttpDelete("{balanceId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public ActionResult DeleteBalance(int balanceId)
        {
            _balanceRepository.Delete(balanceId);
            return NoContent();
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Balance> CreateBalance(Balance balance)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            balance.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value ?? "0");
            var newBalance = _balanceRepository.Add(balance);

            return Created(nameof(GetByBalanceId), balance);
        }



    }
}