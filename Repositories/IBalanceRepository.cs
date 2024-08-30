using fsiplanner_backend.Models;

namespace fsiplanner_backend.Repositories;

public interface IBalanceRepository
{
   Balance GetById(int balanceId);

   IEnumerable<Balance> GetByUsername(string username);

   Balance Update(Balance balance);
   Balance Add(Balance balance);

   void Delete(int balanceId);


}