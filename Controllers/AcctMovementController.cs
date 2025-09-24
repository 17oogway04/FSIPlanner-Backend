using System.Security.Claims;
using fsiplanner_backend.Migrations;
using fsiplanner_backend.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace fsiplanner_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AcctMovementController : ControllerBase
    {
        private readonly ILogger<AcctMovementController> _logger;
        private readonly IAcctMovement _acctRepository;
        private readonly FSIPlannerDbContext _context;

        public AcctMovementController(ILogger<AcctMovementController> logger, IAcctMovement repository, FSIPlannerDbContext context)
        {
            _logger = logger;
            _acctRepository = repository;
            _context = context;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<IEnumerable<AcctMovement>> GetAllAcctMovements()
        {
            return Ok(_acctRepository.GetAllAcctMovements());
        }

        [HttpGet]
        [Route("by-username/{username}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<AcctMovement>>> GetAcctMovementsByUsername(string username)
        {
            IEnumerable<AcctMovement> acctMovements = await _acctRepository.GetAcctMovementsByUsername(username);
            if (acctMovements == null || !acctMovements.Any())
            {
                return NotFound();
            }

            return Ok(acctMovements);
        }

        [HttpGet]
        [Route("by-userId{userId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<AcctMovement>>> GetAcctNoteByUserId(string userId)
        {
            IEnumerable<AcctMovement> acctMovements = (IEnumerable<AcctMovement>)await _acctRepository.GetAcctMovementsByUserId(userId);
            if (acctMovements == null || !acctMovements.Any())
            {
                return NotFound();
            }
            return Ok(acctMovements);
        }

        [HttpGet]
        [Route("by-acctId{acctId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<AcctMovement> GetAccountMovement(int acctMovementId)
        {
            var acctMovement = _acctRepository.GetAcctMovement(acctMovementId);
            if (acctMovement == null)
            {
                return NotFound();
            }

            return Ok(acctMovement);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<AcctMovement> CreateAcctMovement(AcctMovement acctMovement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            acctMovement.UserId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var newAcctMovement = _acctRepository.CreateAcctMovement(acctMovement);
            return Created(nameof(GetAccountMovement), newAcctMovement);
        }

        [HttpPut]
        [Route("{acctId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<AcctMovement> UpdateAcctMovement(AcctMovement acctMovement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(_acctRepository.UpdateAcctMovement(acctMovement));
        }

        [HttpDelete]
        [Route("{acctId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult DeleteAcctMovement(int acctId)
        {
            _acctRepository.DeleteAcctMovement(acctId);
            return NoContent();
        }

    }
}


