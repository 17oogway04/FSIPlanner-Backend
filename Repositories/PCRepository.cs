using fsiplanner_backend.Migrations;
using fsiplanner_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace fsiplanner_backend.Repositories;

public class PCRepository : IPCRepository
{

    private readonly FSIPlannerDbContext _context;

    public PC CreatePC(PC newPC)
    {
        _context.PC.Add(newPC);
        _context.SaveChanges();
        return newPC;
    }

    public void DeletePC(int pcId)
    {
        var pc = _context.PC.Find(pcId);
        if(pc != null)
        {
            _context.PC.Remove(pc);
            _context.SaveChanges();
        }
    }

    public IEnumerable<PC> GetAllPC()
    {
        return _context.PC.ToList();
    }

    public PC GetPCById(int pcId)
    {
        return _context.PC.SingleOrDefault(x => x.PCId == pcId)!;
    }

    public async Task<IEnumerable<PC>> GetPCByUsername(string username)
    {
        return await _context.PC
            .Where(x => x.Username == username)
            .ToListAsync();
    }

    public PC UpdatePC(PC newPC)
    {
        var originalPC = _context.PC.Find(newPC.PCId);

        if(originalPC != null)
        {
            originalPC.CompanyName = newPC.CompanyName;
            originalPC.PolicyType = newPC.PolicyType;
            originalPC.Premium = newPC.Premium;
            originalPC.ExpirationDate = newPC.ExpirationDate;
            originalPC.Deductible = newPC.Deductible;
            originalPC.LiabilityLimit = newPC.LiabilityLimit;
            _context.SaveChanges();
        }

        return originalPC!;
    }
}