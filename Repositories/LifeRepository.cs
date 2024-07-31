using fsiplanner_backend.Migrations;
using fsiplanner_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace fsiplanner_backend.Repositories;

public class LifeRepository : ILifeRepository
{

    private readonly FSIPlannerDbContext _context;

    public LifeRepository(FSIPlannerDbContext context)
    {
        _context = context;
    }

    public Life CreateLife(Life newLife)
    {
        _context.Life.Add(newLife);
        _context.SaveChanges();
        return newLife;
    }

    public void DeleteLife(int lifeId)
    {
        var life = _context.Life.Find(lifeId);
        if(life != null)
        {
            _context.Life.Remove(life);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Life> GetAllLife()
    {
        return _context.Life.ToList();
    }

    public Life GetLifeById(int lifeId)
    {
        return _context.Life.SingleOrDefault(x => x.LifeId == lifeId)!;
    }

    public async Task<IEnumerable<Life>> GetLifeByUserId(int userId)
    {
        return await _context.Life
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Life>> GetLifeByUsername(string username)
    {
        return await _context.Life
            .Where(x => x.Username == username)
            .ToListAsync();
    }

    public Life UpdateLife(Life newLife)
    {
        var originalLife = _context.Life.Find(newLife.LifeId);

        if(originalLife != null)
        {
            originalLife.PolicyName = newLife.PolicyName;
            originalLife.PolicyType = newLife.PolicyType;
            originalLife.Owner = newLife.Owner;
            originalLife.Insured = newLife.Insured;
            originalLife.Premium = newLife.Premium;
            originalLife.CashValue = newLife.CashValue;
            originalLife.DeathBenefitOne = newLife.DeathBenefitOne;
            originalLife.DeathBenefitTwo = newLife.DeathBenefitTwo;
            originalLife.Riders = newLife.Riders;
            originalLife.RidersBenefit = newLife.RidersBenefit;
            originalLife.PercentageToSavings = newLife.PercentageToSavings;
            _context.SaveChanges();
        }

        return originalLife;
    }
}