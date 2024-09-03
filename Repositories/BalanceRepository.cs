
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

    public Balance UpdateBalancesForUser(string username)
    {
        var assets = _context.Asset.Where(a => a.Username == username).ToList();
        var liabilities = _context.Liabilites.Where(a => a.Username == username).ToList();
        var balance = _context.Balances.FirstOrDefault(b => b.Username == username);

        if (balance == null)
        {
            balance = new Balance { Username = username };
            _context.Balances.Add(balance);
        }

        //Assets

        balance.Type1 = assets.Where(a => a.Type == "1").Sum(a => a.Balance);
        balance.Type2 = assets.Where(a => a.Type == "2").Sum(a => a.Balance);
        balance.Type3 = assets.Where(a => a.Type == "3").Sum(a => a.Balance);
        balance.Type4 = assets.Where(a => a.Type == "4").Sum(a => a.Balance);
        balance.Type5 = assets.Where(a => a.Type == "5").Sum(a => a.Balance);
        balance.Type6 = assets.Where(a => a.Type == "6").Sum(a => a.Balance);
        balance.Type7 = assets.Where(a => a.Type == "7").Sum(a => a.Balance);
        balance.Type8 = assets.Where(a => a.Type == "8").Sum(a => a.Balance);
        balance.Type9 = assets.Where(a => a.Type == "9").Sum(a => a.Balance);
        balance.Type10 = assets.Where(a => a.Type == "10").Sum(a => a.Balance);
        balance.Type11 = assets.Where(a => a.Type == "11").Sum(a => a.Balance);
        balance.Type12 = assets.Where(a => a.Type == "12").Sum(a => a.Balance);
        balance.Type13 = assets.Where(a => a.Type == "13").Sum(a => a.Balance);
        balance.Type14 = assets.Where(a => a.Type == "14").Sum(a => a.Balance);
        balance.Type15 = assets.Where(a => a.Type == "15").Sum(a => a.Balance);
        balance.Type16 = assets.Where(a => a.Type == "16").Sum(a => a.Balance);
        balance.Type17 = assets.Where(a => a.Type == "17").Sum(a => a.Balance);
        balance.Type18 = assets.Where(a => a.Type == "18").Sum(a => a.Balance);
        balance.Type19 = assets.Where(a => a.Type == "19").Sum(a => a.Balance);
        balance.Type20 = assets.Where(a => a.Type == "20").Sum(a => a.Balance);
        balance.Type21 = assets.Where(a => a.Type == "21").Sum(a => a.Balance);
        balance.Type22 = assets.Where(a => a.Type == "22").Sum(a => a.Balance);

        //Liabilities
        balance.Type1 -= liabilities.Where(a => a.Type == "1").Sum(a => a.Balance);
        balance.Type2 -= liabilities.Where(a => a.Type == "2").Sum(a => a.Balance);
        balance.Type3 -= liabilities.Where(a => a.Type == "3").Sum(a => a.Balance);
        balance.Type4 -= liabilities.Where(a => a.Type == "4").Sum(a => a.Balance);
        balance.Type5 -= liabilities.Where(a => a.Type == "5").Sum(a => a.Balance);
        balance.Type6 -= liabilities.Where(a => a.Type == "6").Sum(a => a.Balance);
        balance.Type7 -= liabilities.Where(a => a.Type == "7").Sum(a => a.Balance);
        balance.Type8 -= liabilities.Where(a => a.Type == "8").Sum(a => a.Balance);
        balance.Type9 -= liabilities.Where(a => a.Type == "9").Sum(a => a.Balance);
        balance.Type10 -= liabilities.Where(a => a.Type == "10").Sum(a => a.Balance);
        balance.Type11 -= liabilities.Where(a => a.Type == "11").Sum(a => a.Balance);
        balance.Type12 -= liabilities.Where(a => a.Type == "12").Sum(a => a.Balance);
        balance.Type13 -= liabilities.Where(a => a.Type == "13").Sum(a => a.Balance);
        balance.Type14 -= liabilities.Where(a => a.Type == "14").Sum(a => a.Balance);
        balance.Type15 -= liabilities.Where(a => a.Type == "15").Sum(a => a.Balance);
        balance.Type16 -= liabilities.Where(a => a.Type == "16").Sum(a => a.Balance);
        balance.Type17 -= liabilities.Where(a => a.Type == "17").Sum(a => a.Balance);
        balance.Type18 -= liabilities.Where(a => a.Type == "18").Sum(a => a.Balance);
        balance.Type19 -= liabilities.Where(a => a.Type == "19").Sum(a => a.Balance);
        balance.Type20 -= liabilities.Where(a => a.Type == "20").Sum(a => a.Balance);
        balance.Type21 -= liabilities.Where(a => a.Type == "21").Sum(a => a.Balance);
        balance.Type22 -= liabilities.Where(a => a.Type == "22").Sum(a => a.Balance);

        _context.SaveChanges();
        return balance;
    }
}