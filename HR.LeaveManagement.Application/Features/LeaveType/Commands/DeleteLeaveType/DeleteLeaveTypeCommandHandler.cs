﻿using HR.LeaveManagement.Application.Contracts.Persistence;
using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async ValueTask<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // retrieve domain entity object
            var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);

            // verify that record exists
            if (leaveTypeToDelete == null)
                throw new Exception();
            //throw new NotFoundException(nameof(LeaveType), request.Id);

            // remove from database
            await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

            // retun record id
            return Unit.Value;
        }
    }
}