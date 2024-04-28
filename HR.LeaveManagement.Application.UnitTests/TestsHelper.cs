using HRLeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnitTests
{
    public static class TestsHelper
    {
        public static List<LeaveType> leaveTypes = new List<LeaveType>
        {
                new LeaveType
                {
                    Id = 1,
                    DefaultDays = 10,
                    Name = "Test Sick",
                },

                new LeaveType
                {
                    Id = 2,
                    DefaultDays = 5,
                    Name = "Test Vacation",
                }
         };
    }
}
