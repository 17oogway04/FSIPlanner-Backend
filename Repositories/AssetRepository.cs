using fsiplanner_backend.Migrations;
using fsiplanner_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace fsiplanner_backend.Repositories;

public class AssetRepository : IAssetRepository
{

    private readonly FSIPlannerDbContext _context;

    public AssetRepository(FSIPlannerDbContext context)
    {
        _context = context;
    }

    public Assets CreateAsset(Assets newAsset)
    {
        _context.Asset.Add(newAsset);
        _context.SaveChanges();
        return newAsset;
    }

    public void DeleteAsset(int assetId)
    {
        var asset = _context.Asset.Find(assetId);
        if(asset != null)
        {
            _context.Asset.Remove(asset);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Assets> GetAllAssets()
    {
        return _context.Asset.ToList();
    }

    public Assets GetAsset(int assetId)
    {
        return _context.Asset.SingleOrDefault(c => c.AssetId == assetId)!;
    }

    public async Task<IEnumerable<Assets>> GetAssetsByUserId(int userId)
    {
        return await _context.Asset
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Assets>> GetAssetsByUsername(string username)
    {
        return await _context.Asset 
            .Where(x => x.Username == username)
            .ToListAsync();
    }

    public Assets UpdateAsset(Assets newAsset)
    {
        var originalAsset = _context.Asset.Find(newAsset.AssetId);
        if(originalAsset != null)
        {
            originalAsset.Balance = newAsset.Balance;
            originalAsset.AccountNumber = newAsset.AccountNumber;
            originalAsset.Bucket = newAsset.Bucket;
            originalAsset.Custodian = newAsset.Custodian;
            originalAsset.MaturityDate = newAsset.MaturityDate;
            originalAsset.RateOfReturn = newAsset.RateOfReturn;
            originalAsset.TaxStructure = newAsset.TaxStructure;
            originalAsset.ValuationDate = newAsset.ValuationDate;
            originalAsset.Type = newAsset.Type;
            originalAsset.AssetName = newAsset.AssetName;
            _context.SaveChanges();
        }

        return originalAsset!;

    }
}