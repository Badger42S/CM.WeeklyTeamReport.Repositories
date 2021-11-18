using CM.WeeklyTeamReport.Domain;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CM.WeeklyTeamReport.Repositories.Tests
{
    public class TeamMemberRepositoryTest
    {
        [Fact]
        public void ShouldBeAbleToCreateTeamMemberRepository()
        {
            var teamMemberRepository = new TeamMemberRepository();
            teamMemberRepository.Should().NotBeNull();
        }
        [Fact]
        public void ShouldBeAbleToAddTeamMember()
        {
            var teamMemberRepository = new TeamMemberRepository();
            var teamTeamMember = new TeamMember(1, 3, "Pasha", "Pavluk", Roles.junior);
            var newTeamTeamMember = teamMemberRepository.Create(teamTeamMember);
            newTeamTeamMember.CompanyId.Should().Equals(teamTeamMember.CompanyId);
            newTeamTeamMember.FirstName.Should().Equals(teamTeamMember.FirstName);
            newTeamTeamMember.LastName.Should().Equals(teamTeamMember.LastName);
            newTeamTeamMember.TeamMemberId.Should().Equals(teamTeamMember.TeamMemberId);
            newTeamTeamMember.Role.Should().Equals(teamTeamMember.Role);
        }
        
    }
}
