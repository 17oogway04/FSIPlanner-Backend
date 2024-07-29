using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fsiplanner_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BalanceController : ControllerBase
    {
        private static readonly Dictionary<string, int> _hashMap = new Dictionary<string, int>
        {
            {"1", 0},
            {"2", 0},
            {"3", 0},
            {"4", 0},
            {"5", 0},
            {"6", 0},
            {"7", 0},
            {"8", 0},
            {"9", 0},
            {"10", 0},
            {"11", 0},
            {"12", 0},
            {"13", 0},
            {"14", 0},
            {"15", 0},
            {"16", 0},
            {"17", 0},
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