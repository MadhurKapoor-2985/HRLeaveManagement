using HRLeaveSystem.Application.Contracts.Persistence;
using HRLeaveSystem.Domain;
using HRLeaveSystem.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HRLeaveSystem.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
        {
        }

        public async Task AddAllocations(List<LeaveAllocation> allocations)
        {
            await _context.AddRangeAsync(allocations);
        }

        public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
        {
            return await _context.LeaveAllocations.AnyAsync(x => x.EmployeeId == userId && x.LeaveTypeId == leaveTypeId && x.Period == period);
        }

        public Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var leaveAllocations = _context.LeaveAllocations
                                    .Include(x => x.LeaveType)
                                    .ToListAsync();
            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocations = await _context.LeaveAllocations
                                    .Include(x => x.LeaveType)
                                    .FirstOrDefaultAsync(x => x.Id == id);
            return leaveAllocations;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId)
        {
            var leaveAllocations = await _context.LeaveAllocations
                                    .Include(x => x.LeaveType)
                                    .Where(x => x.EmployeeId == userId)
                                    .ToListAsync();
            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
        {
            var leaveAllocations = await _context.LeaveAllocations
                                   .Include(x => x.LeaveType)
                                   .FirstOrDefaultAsync(x => x.EmployeeId == userId && x.LeaveTypeId == leaveTypeId);
                                   
            return leaveAllocations;
        }
    }
}
