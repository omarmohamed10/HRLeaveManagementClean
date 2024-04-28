using HR.LeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnitTests.Mocks
{
    public class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetMockLeaveTypeRepository()
        {
            var mockRepo = new Mock<ILeaveTypeRepository>();

            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(TestsHelper.leaveTypes);
            mockRepo.Setup(r => r.CreateAsync(It.IsAny<LeaveType>())) 
                .Returns((LeaveType leaveType) =>
                {
                    TestsHelper.leaveTypes.Add(leaveType);
                    return Task.CompletedTask;
                });

            return mockRepo;
        }
    }
}
