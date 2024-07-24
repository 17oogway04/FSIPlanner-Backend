using fsiplanner_backend.Models;

namespace fsiplanner_backend.Repositories;

public interface IPCRepository
{
    IEnumerable<PC> GetAllPC();
    Task<IEnumerable<PC>> GetPCByUsername(string username);
    PC GetPCById(int pcId);
    PC CreatePC(PC newPC);
    PC UpdatePC(PC newPC);
    void DeletePC(int pcId);
}