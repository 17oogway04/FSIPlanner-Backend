using fsiplanner_backend.Models;

namespace fsiplanner_backend.Repositories;

public interface IAssetRepository
{
    IEnumerable<Assets> GetAllAssets();
    Task<IEnumerable<Assets>> GetAssetsByUsername(string username);
    Task<IEnumerable<Assets>> GetAssetsByUserId(string userId);
    Assets GetAsset(int assetId);
    Assets CreateAsset(Assets newAsset);
    Assets UpdateAsset(Assets newAsset);
    void DeleteAsset(int assetId);
}