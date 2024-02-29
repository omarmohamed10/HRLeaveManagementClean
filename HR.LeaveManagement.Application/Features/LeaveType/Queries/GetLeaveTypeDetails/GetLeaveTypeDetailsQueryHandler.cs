using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
    public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypeDetailsQuery, GetLeaveTypeDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async ValueTask<GetLeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);

            var leaveTypeDetailsDto = _mapper.Map<GetLeaveTypeDetailsDto>(leaveType);

            return leaveTypeDetailsDto;
        }
    }
}
