using System;
using Xunit;

namespace CM.WeeklyTeamReport.Domain.Tests
{
    public class TeamMemberTest
    {
        [Fact]
        public void ShouldBeTeamMember()
        {
            string firstName = "John";
            string lastName = "Doe";
            var role = Roles.junior;
            var teamMember = new TeamMember(1, firstName, lastName, role, 5);
            Assert.NotNull(teamMember);
            Assert.Equal("John", teamMember.FirstName);
            Assert.Equal("Doe", teamMember.LastName);
            Assert.Equal(Roles.junior, teamMember.Role);
            Assert.Equal(1, teamMember.CompanyId);
            Assert.Equal(5, teamMember.TeamMemberId);
        }
    }
}
