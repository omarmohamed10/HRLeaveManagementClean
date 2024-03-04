using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using Mediator;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async ValueTask<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var leaveTypeToCreate = _mapper.Map<HRLeaveManagement.Domain.LeaveType>(request);

                await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);

                return leaveTypeToCreate.Id;
            }
            return 0;
        }
    }
}
