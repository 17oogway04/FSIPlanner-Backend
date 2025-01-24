using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using fsiplanner_backend.Migrations;
using fsiplanner_backend.Models;
using fsiplanner_backend.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fsiplanner_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly ILogger<AssetController> _logger;
        private readonly IAssetRepository _assetRepository;
        private readonly FSIPlannerDbContext _context;

        public AssetController(ILogger<AssetController> logger, IAssetRepository repository, FSIPlannerDbContext context)
        {
            _logger = logger;
            _assetRepository = repository;
            _context = context;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<IEnumerable<Assets>> GetAllAssets()
        {
            return Ok(_assetRepository.GetAllAssets());
        }

        [HttpGet]
        [Route("by-username/{username}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<Assets>>> GetAssetsByUsername(string username)
        {
            IEnumerable<Assets> asset = await _assetRepository.GetAssetsByUsername(username);
            if (asset == null || !asset.Any())
            {
                return NotFound();
            }

            return Ok(asset);
        }

        [HttpGet]
        [Route("by-userId{userId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<Assets>>> GetAssetsByUserId(string userId)
        {
            IEnumerable<Assets> asset = (IEnumerable<Assets>)await _assetRepository.GetAssetsByUserId(userId);
            if (asset == null || !asset.Any())
            {
                return NotFound();
            }
            return Ok(asset);
        }

        [HttpGet]
        [Route("by-assetId{assetId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Assets> GetAsset(int assetId)
        {
            var asset = _assetRepository.GetAsset(assetId);
            if (asset == null)
            {
                return NotFound();
            }

            return Ok(asset);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Assets> CreateAsset(Assets asset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            asset.UserId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var newAsset = _assetRepository.CreateAsset(asset);
            return Created(nameof(GetAsset), newAsset);
        }

        [HttpPut]
        [Route("{assetId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Assets> UpdateAsset(Assets asset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(_assetRepository.UpdateAsset(asset));
        }

        [HttpDelete]
        [Route("{assetId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult DeleteAsset(int assetId)
        {
            _assetRepository.DeleteAsset(assetId);
            return NoContent();
        }
        [HttpGet("buckets/{username?}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<BucketSummary>>> GetBuckets(string? username = null)
        {
            if (username == null)
            {
                username = User.FindFirst(JwtRegisteredClaimNames.Name)?.Value;
                if (username == null)
                {
                    return Unauthorized();
                }
            }

            var summaries = await _context.Asset
                .Where(a => a.Username == username)
                .GroupBy(a => a.Bucket)
                .Select(g => new BucketSummary
                {
                    Bucket = g.Key,
                    Balance = g.Sum(a => a.Balance)
                })
                .ToListAsync();

            return Ok(summaries);
        }
    }


}

