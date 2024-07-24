using fsiplanner_backend.Models;

namespace fsiplanner_backend.Repositories;

public interface ILifeRepository
{
    IEnumerable<Life> GetAllLife();
    Task<IEnumerable<Life>> GetLifeByUsername(string username);
    Life GetLifeById (int lifeId);
    Life CreateLife(Life newLife);
    Life UpdateLife(Life newLife);
    void DeleteLife(int lifeId);
}