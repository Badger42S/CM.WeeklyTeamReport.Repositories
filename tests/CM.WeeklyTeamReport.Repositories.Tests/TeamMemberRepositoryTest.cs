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
        [Fact]
        public void ShouldBeAbleToReadTeamMember()
        {
            var teamMemberRepository = new TeamMemberRepository();
            var readTeamMember = teamMemberRepository.Read(3);
            readTeamMember.TeamMemberId.Should().Equals(3);
        }
        [Fact]
        public void ShouldBeAbleToDeleteTeamMember()
        {
            var teamMemberRepository = new TeamMemberRepository();
            var deletedTeamMember = teamMemberRepository.Read(6);
            deletedTeamMember.Should().NotBeNull();
            teamMemberRepository.Delete(6);
            deletedTeamMember = teamMemberRepository.Read(6);
            deletedTeamMember.Should().BeNull();
        }
        [Fact]
        public void ShouldBeAbleToUpdateTeamMember()
        {
            var teamMemberRepository = new TeamMemberRepository();
            var teamTeamMember = new TeamMember(1, 4, "Gena", "Jolas", Roles.manager);
            teamMemberRepository.Update(teamTeamMember.TeamMemberId, teamTeamMember);
            var updatedTeamMember = teamMemberRepository.Read(teamTeamMember.TeamMemberId);
            updatedTeamMember.Should().NotBeNull();
            updatedTeamMember.LastName.Should().Equals(teamTeamMember.LastName);
            updatedTeamMember.FirstName.Should().Equals(teamTeamMember.FirstName);
            updatedTeamMember.CompanyId.Should().Equals(teamTeamMember.CompanyId);
            updatedTeamMember.Role.Should().Equals(teamTeamMember.Role);
        }
    }
}
