using HRLeaveSystem.Application.Contracts.Persistence;
using HRLeaveSystem.Domain;
using HRLeaveSystem.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HRLeaveSystem.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(HrDatabaseContext context) : base(context)
        {
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
        {
            var leaveRequests = await _context.LeaveRequests
                                      .Include(q => q.LeaveType)
                                      .ToListAsync();
            return leaveRequests;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = await _context.LeaveRequests
                                .Include(q => q.LeaveType)
                                .FirstOrDefaultAsync(q => q.Id == id);
            return leaveRequest;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId)
        {
            var leaveRequests = await _context.LeaveRequests
                           .Where(x => x.RequestingEmployeeId == userId)
                          .Include(q => q.LeaveType)
                          .ToListAsync();
            return leaveRequests;
        }
    }
}
