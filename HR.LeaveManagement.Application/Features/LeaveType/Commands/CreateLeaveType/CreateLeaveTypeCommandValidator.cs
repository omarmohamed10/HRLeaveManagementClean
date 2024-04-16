using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .NotNull()
                .MaximumLength(100)
                .WithMessage("Name must be equal or fewer than 100 characters");

            RuleFor(x => x.DefaultDays)
                .LessThan(100)
                .WithMessage("{PropertyName} cannot exceed 100")
                .GreaterThan(1)
                .WithMessage("{PropertyName} cannot be less than 1");

            RuleFor(x => x)
                .MustAsync(LeaveTypeNameUnique)
                .WithMessage("Leave type already exist");

            _leaveTypeRepository = leaveTypeRepository;
        }

        private Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommand command, CancellationToken token)
        {
            return _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
        }
    }
}
