using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HRLeaveManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypeQuery, List<LeaveTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<GetLeaveTypesQueryHandler> _logger;

        public GetLeaveTypesQueryHandler(IMapper mapper, 
                                        ILeaveTypeRepository leaveTypeRepository,
                                        IAppLogger<GetLeaveTypesQueryHandler> logger)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _logger = logger;
        }
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeQuery request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _leaveTypeRepository.GetAsync();

            if (leaveTypes == null)
                throw new NotFoundException(nameof(LeaveType), request);

            var leaveTypesDtos = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

            _logger.LogInformation("Leave Types retured Successfully");

            return leaveTypesDtos;
        }
    }
}
