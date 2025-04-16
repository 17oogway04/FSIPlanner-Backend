using fsiplanner_backend.Models;

namespace fsiplanner_backend.Repositories;

public interface IDisabilityInsRepository
{
    IEnumerable<DisabilityInsurance> GetAllDisabilityIns();
    Task<IEnumerable<DisabilityInsurance>> GetDisabilityInsByUsername(string username);
    Task<IEnumerable<DisabilityInsurance>> GetDisabilityInsByUserId(string userId);
    DisabilityInsurance GetDisabilityInsById(int disabilityInsId);
    DisabilityInsurance CreateDisabilityIns(DisabilityInsurance newDisability);
    DisabilityInsurance UpdateDisabilityIns(DisabilityInsurance newDisability);
    void DeleteDisabilityIns(int disabilityInsId);
}