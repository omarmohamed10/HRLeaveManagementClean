using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
    public class GetLeaveTypeDetailsQuery : IRequest<GetLeaveTypeDetailsDto>
    {
        public int Id { get; }
    }
}
