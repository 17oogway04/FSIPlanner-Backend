using fsiplanner_backend.Migrations;
using fsiplanner_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace fsiplanner_backend.Repositories;

public class LiabilityRepository : ILiabilityRepository
{
    private readonly FSIPlannerDbContext _context;

    public LiabilityRepository(FSIPlannerDbContext context)
    {
        _context = context;
    }
    public Liabilities CreateLiability(Liabilities newLiability)
    {
        _context.Liabilites.Add(newLiability);
        _context.SaveChanges();
        return newLiability;
    }

    public void DeleteLiability(int liabilityId)
    {
        var liability = _context.Liabilites.Find(liabilityId);
        if(liability != null)
        {
            _context.Liabilites.Remove(liability);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Liabilities> GetAllLiabilites()
    {
        return _context.Liabilites.ToList();
    }

    public Liabilities GetLiabilitiesById(int liabilityId)
    {
        return _context.Liabilites.SingleOrDefault(l => l.LiabilitiesId == liabilityId)!;
    }

    public async Task<IEnumerable<Liabilities>> GetLiabilitiesByUserId(string userId)
    {
        return await _context.Liabilites
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Liabilities>> GetLiabilitiesByUsername(string username)
    {
        return await _context.Liabilites
            .Where(x => x.Username == username)
            .ToListAsync();
    }

    public Liabilities UpdateLiability(Liabilities newLiability)
    {
        var originalLiability = _context.Liabilites.Find(newLiability.LiabilitiesId);

        if(originalLiability != null)
        {
            originalLiability.Type = newLiability.Type;
            originalLiability.Description = newLiability.Description;
            originalLiability.Balance = newLiability.Balance;
            originalLiability.Rate = newLiability.Rate;
            originalLiability.Payment = newLiability.Payment;
            originalLiability.Term = newLiability.Term;
            originalLiability.Value = newLiability.Value;
            _context.SaveChanges();
        }

        return originalLiability!;
    }
}