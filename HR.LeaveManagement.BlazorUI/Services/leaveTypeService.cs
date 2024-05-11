using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Services.Base;

namespace HR.LeaveManagement.BlazorUI.Services
{
    public class leaveTypeService : BaseHttpService, IleaveTypeService
    {
        public leaveTypeService(IClient client) : base(client)
        {
        }
    }
}
