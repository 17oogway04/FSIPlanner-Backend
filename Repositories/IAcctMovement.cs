namespace fsiplanner_backend.Repositories;

public interface IAcctMovement
{

    IEnumerable<AcctMovement> GetAllAcctMovements();
    Task<IEnumerable<AcctMovement>> GetAcctMovementsByUsername(string username);
    Task<IEnumerable<AcctMovement>> GetAcctMovementsByUserId(string userId);
    AcctMovement GetAcctMovement(int acctId);
    AcctMovement CreateAcctMovement(AcctMovement newAcctMovement);
    AcctMovement UpdateAcctMovement(AcctMovement newAcctMovement);
    void DeleteAcctMovement(int acctId);
}
