using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
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
            var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validationResults = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResults.IsValid)
                throw new BadRequestException("Invalid LeaveType", validationResults);

            var leaveTypeToCreate = _mapper.Map<HRLeaveManagement.Domain.LeaveType>(request);

            await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);

            return leaveTypeToCreate.Id;

        }
    }
}
