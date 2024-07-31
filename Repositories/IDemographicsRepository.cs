using fsiplanner_backend.Models;

namespace fsiplanner_backend.Repositories;

public interface IDemographicsRepository
{
    IEnumerable<Demographics> GetAllDemographics();
    Task<IEnumerable<Demographics>> GetDemographicsByUsername(string username);
    Task<IEnumerable<Demographics>> GetDemographicsByUserId(int userId);
    Demographics GetDemographic(int demographicId);
    Demographics CreateDemographics(Demographics newDemographic);
    Demographics UpdateDemographic(Demographics newDemographic);
    void DeleteDemographic(int demographicId);
}