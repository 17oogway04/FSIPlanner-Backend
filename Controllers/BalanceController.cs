using System.IdentityModel.Tokens.Jwt;
using fsiplanner_backend.Migrations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fsiplanner_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BalanceController : ControllerBase
    {

        private readonly FSIPlannerDbContext _context;
        private static readonly Dictionary<string, int> _hashMap = new Dictionary<string, int>
        {
            {"1", 0}, //Checking
            {"2", 0}, //Currency
            {"3", 0}, //Savings
            {"4", 0}, //CDs
            {"5", 0}, //Health and Medical Savings
            {"6", 0}, //Life Insurance
            {"7", 0}, //Annuities
            {"8", 0}, //Investments
            {"9", 0}, //IRAs
            {"10", 0}, //Roth IRA
            {"11", 0}, //Employer retirement plan
            {"12", 0}, //Bullion
            {"13", 0}, //Primary Residence
            {"14", 0}, //Secondary Residence
            {"15", 0}, //Real Estate
            {"16", 0}, //Business
            {"17", 0}, //Trust
            {"18", 0}, //Vehicles
            {"19", 0}, //Personal Property
            {"20", 0}, //Credit Cards
            {"21", 0}, //Student Loans
            {"22", 0} //Other
        };

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Dictionary<string, int>> GetBalanceMap()
        {
            return Ok(_hashMap);
        }

        [HttpPost("update")]

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Dictionary<string, int>> UpdateBalanceMap([FromBody] Dictionary<string, int> updates)
        {
            foreach (var kvp in updates)
            {
                if(_hashMap.ContainsKey(kvp.Key))
                {
                    _hashMap[kvp.Key] += kvp.Value;
                }
            }
            return Ok(_hashMap);
        }

        [HttpDelete("delete/{key}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Dictionary<string, int>> DeleteBalanceMapEntry(string key)
        {
            if(_hashMap.ContainsKey(key))
            {
                _hashMap.Remove(key);
                return Ok(_hashMap);
            }

            return NotFound(new{ Message = "Key not found"});
        }

    }
}