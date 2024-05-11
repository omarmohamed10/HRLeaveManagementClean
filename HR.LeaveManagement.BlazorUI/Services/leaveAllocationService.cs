using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Services.Base;

namespace HR.LeaveManagement.BlazorUI.Services
{
    public class leaveAllocationService : BaseHttpService, IleaveAllocationService
    {
        public leaveAllocationService(IClient client) : base(client)
        {
        }
    }
}
