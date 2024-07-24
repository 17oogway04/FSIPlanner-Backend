using fsiplanner_backend.Models;

namespace fsiplanner_backend.Repositories;

public interface IDisabilityInsRepository
{
    IEnumerable<DisabilityInsurance> GetAllDisabilityIns();
    Task<IEnumerable<DisabilityInsurance>> GetDisabilityInsByUsername(string username);
    DisabilityInsurance GetDisabilityInsById(int disabilityInsId);
    DisabilityInsurance CreateDisabilityIns(DisabilityInsurance newDisability);
    DisabilityInsurance UpdateDisabilityIns(DisabilityInsurance newDisability);
    void DeleteDisabilityIns(int disabilityInsId);
}