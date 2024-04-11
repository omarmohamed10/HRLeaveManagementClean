using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Persistence.DatabaseContext;
using HRLeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(HRDatabaseContext context) : base(context)
        {
        }

        public async Task AddAllocations(List<LeaveAllocation> allocations)
        {
            await _context.AddRangeAsync(allocations);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
        {
           return await _context.LeaveAllocations.AnyAsync(x => x.EmployeeId == userId 
                                                        && x.LeaveTypeId == leaveTypeId 
                                                        && x.Period == period);
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            return await _context.LeaveAllocations
                              .Include(x => x.LeaveType)
                              .ToListAsync();
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
        {
            return await _context.LeaveAllocations
                                       .Where(x => x.EmployeeId == userId)
                                       .Include(x => x.LeaveType)
                                       .ToListAsync();
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var leaveAllocation =  await _context.LeaveAllocations
                             .Include(x => x.LeaveType)
                             .FirstOrDefaultAsync(x => x.Id == id);

            if (leaveAllocation == null) 
                throw new Exception($"Id @{id} doesn't Exist");

            return leaveAllocation;
        }

        public async Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
        {
            var leaveAllocation = await _context.LeaveAllocations.FirstOrDefaultAsync(q => q.EmployeeId == userId
                                                    && q.LeaveTypeId == leaveTypeId);
            if (leaveAllocation == null)
                throw new Exception($"LeaveAllocation with userID @{userId} and LeaveTypeId @{leaveTypeId} doesn't Exist");

            return leaveAllocation;

        }
    }
}
