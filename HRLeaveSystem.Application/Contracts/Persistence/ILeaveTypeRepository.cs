using HRLeaveSystem.Domain;

namespace HRLeaveSystem.Application.Contracts.Persistence
{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
    {
        Task<bool> IsLeaveTypeNameUnique(string name);
    }


}
