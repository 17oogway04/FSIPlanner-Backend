
using fsiplanner_backend.Migrations;
using Microsoft.EntityFrameworkCore;

namespace fsiplanner_backend.Repositories;

public class AcctMovementRepository : IAcctMovement
{
    private readonly FSIPlannerDbContext _context;

    public AcctMovementRepository(FSIPlannerDbContext context)
    {
        _context = context;
    }
    public AcctMovement CreateAcctMovement(AcctMovement newAcctMovement)
    {
        _context.AcctMovements.Add(newAcctMovement);
        _context.SaveChanges();
        return newAcctMovement;
    }

    public void DeleteAcctMovement(int acctId)
    {
        var acctmovement = _context.AcctMovements.Find(acctId);
        if (acctmovement != null)
        {
            _context.AcctMovements.Remove(acctmovement);
            _context.SaveChanges();
        }
    }

    public AcctMovement GetAcctMovement(int acctId)
    {
        return _context.AcctMovements.SingleOrDefault(c => c.AcctMovementId == acctId)!;
    }

    public async Task<IEnumerable<AcctMovement>> GetAcctMovementsByUserId(string userId)
    {
        return await _context.AcctMovements
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }

    public async Task<IEnumerable<AcctMovement>> GetAcctMovementsByUsername(string username)
    {
        return await _context.AcctMovements
            .Where(c => c.Username == username)
            .ToListAsync();
    }

    public IEnumerable<AcctMovement> GetAllAcctMovements()
    {
        return _context.AcctMovements.ToList();
    }

    public AcctMovement UpdateAcctMovement(AcctMovement newAcctMovement)
    {
        var ogAcctNote = _context.AcctMovements.Find(newAcctMovement.AcctMovementId);
        if (ogAcctNote != null)
        {
            ogAcctNote.FullOrPartial = newAcctMovement.FullOrPartial;
            ogAcctNote.CompanyFrom = newAcctMovement.CompanyFrom;
            ogAcctNote.CompanyTo = newAcctMovement.CompanyTo;
            ogAcctNote.DollarAmt = newAcctMovement.DollarAmt;
            ogAcctNote.Date = newAcctMovement.Date;
            _context.SaveChanges();
        }

        return ogAcctNote!;
    }
}
