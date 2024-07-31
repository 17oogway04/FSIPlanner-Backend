using fsiplanner_backend.Models;

namespace fsiplanner_backend.Repositories;

public interface ILiabilityRepository
{
    IEnumerable<Liabilities> GetAllLiabilites();
    Task<IEnumerable<Liabilities>> GetLiabilitiesByUsername(string username);
    Task<IEnumerable<Liabilities>> GetLiabilitiesByUserId(int userId);
    Liabilities GetLiabilitiesById(int liabilityId);
    Liabilities CreateLiability(Liabilities newLiability);
    Liabilities UpdateLiability(Liabilities newLiability);
    void DeleteLiability(int liabilityId);
}