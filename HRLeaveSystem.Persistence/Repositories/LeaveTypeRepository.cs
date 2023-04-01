using HRLeaveSystem.Application.Contracts.Persistence;
using HRLeaveSystem.Domain;
using HRLeaveSystem.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveSystem.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(HrDatabaseContext context) : base(context)
        {
        }

        public async Task<bool> IsLeaveTypeNameUnique(string name)
        {
            return await _context.LeaveTypes.AnyAsync(t => t.Name == name);
        }
    }
}
