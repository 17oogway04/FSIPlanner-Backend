
using fsiplanner_backend.Migrations;
using fsiplanner_backend.Models;

namespace fsiplanner_backend.Repositories;

public class BalanceRepository : IBalanceRepository
{
    private readonly FSIPlannerDbContext _context;

    public BalanceRepository(FSIPlannerDbContext context)
    {
        _context = context;
    }

    public Balance Add(Balance balance)
    {
        _context.Balances.Add(balance);
        _context.SaveChanges();
        return balance;
    }

    public void Delete(int balanceId)
    {
        var balance = GetById(balanceId);
        _context.Balances.Remove(balance);
        _context.SaveChanges();
    }

    public Balance GetById(int balanceId)
    {
        return _context.Balances.Find(balanceId)
            ?? throw new KeyNotFoundException("Balance not found");
    }

    public IEnumerable<Balance> GetByUsername(string username)
    {
        return _context.Balances.Where(b => b.Username == username).ToList();
    }



    public Balance Update(Balance balance)
    {
        var originalBalances = _context.Balances.Find(balance.BalanceId);
        if (originalBalances != null)
        {
            originalBalances.Type1 = balance.Type1;
            originalBalances.Type2 = balance.Type2;
            originalBalances.Type3 = balance.Type3;
            originalBalances.Type4 = balance.Type4;
            originalBalances.Type5 = balance.Type5;
            originalBalances.Type6 = balance.Type6;
            originalBalances.Type7 = balance.Type7;
            originalBalances.Type8 = balance.Type8;
            originalBalances.Type9 = balance.Type9;
            originalBalances.Type10 = balance.Type10;
            originalBalances.Type11 = balance.Type11;
            originalBalances.Type12 = balance.Type12;
            originalBalances.Type13 = balance.Type13;
            originalBalances.Type14 = balance.Type14;
            originalBalances.Type15 = balance.Type15;
            originalBalances.Type16 = balance.Type16;
            originalBalances.Type17 = balance.Type17;
            originalBalances.Type18 = balance.Type18;
            originalBalances.Type19 = balance.Type19;
            originalBalances.Type20 = balance.Type20;
            originalBalances.Type21 = balance.Type21;
            originalBalances.Type22 = balance.Type22;

            _context.SaveChanges();
        }
        return originalBalances!;
    }


}