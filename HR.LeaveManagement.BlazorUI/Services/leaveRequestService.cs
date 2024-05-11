using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Services.Base;

namespace HR.LeaveManagement.BlazorUI.Services
{
    public class leaveRequestService : BaseHttpService, IleaveRequestService
    {
        public leaveRequestService(IClient client) : base(client)
        {
        }
    }
}
