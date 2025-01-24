using fsiplanner_backend.Migrations;
using fsiplanner_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace fsiplanner_backend.Repositories;

public class DisabilityInsRepository : IDisabilityInsRepository
{

    private readonly FSIPlannerDbContext _context;

    public DisabilityInsRepository(FSIPlannerDbContext context)
    {
        _context = context;
    }

    public DisabilityInsurance CreateDisabilityIns(DisabilityInsurance newDisability)
    {
        _context.DisabilityIns.Add(newDisability);
        _context.SaveChanges();
        return newDisability;
    }

    public void DeleteDisabilityIns(int disabilityInsId)
    {
        var disabilityIns = _context.DisabilityIns.Find(disabilityInsId);
        if(disabilityIns != null)
        {
            _context.DisabilityIns.Remove(disabilityIns);
            _context.SaveChanges();
        }
    }

    public IEnumerable<DisabilityInsurance> GetAllDisabilityIns()
    {
        return _context.DisabilityIns.ToList();
    }

    public DisabilityInsurance GetDisabilityInsById(int disabilityInsId)
    {
        return _context.DisabilityIns.SingleOrDefault(x => x.DisabilityInsId == disabilityInsId)!;
    }

    public async Task<IEnumerable<DisabilityInsurance>> GetDisabilityInsByUserId(string userId)
    {
        return await _context.DisabilityIns
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }

    public async Task<IEnumerable<DisabilityInsurance>> GetDisabilityInsByUsername(string username)
    {
        return await _context.DisabilityIns
            .Where(x => x.Username == username)
            .ToListAsync();
    }

    public DisabilityInsurance UpdateDisabilityIns(DisabilityInsurance newDisability)
    {
        var originalDisability = _context.DisabilityIns.Find(newDisability.DisabilityInsId);

        if(originalDisability != null)
        {
            originalDisability.PolicyName = newDisability.PolicyName;
            originalDisability.PolicyType =  newDisability.PolicyType;
            originalDisability.Owner = newDisability.Owner;
            originalDisability.Insured = newDisability.Insured;
            originalDisability.Premium = newDisability.Premium;
            originalDisability.CashValue = newDisability.CashValue;
            originalDisability.MonthlyDeathBenefitOne = newDisability.MonthlyDeathBenefitOne;
            originalDisability.MonthlyDeathBenefitTwo = newDisability.MonthlyDeathBenefitTwo;
            originalDisability.Riders = newDisability.Riders;
            originalDisability.RidersBenefit = newDisability.RidersBenefit;
            originalDisability.EliminationPeriod = newDisability.EliminationPeriod;
            originalDisability.BenefitPeriod = newDisability.BenefitPeriod;
            _context.SaveChanges();
        }

        return originalDisability!;
    }
}