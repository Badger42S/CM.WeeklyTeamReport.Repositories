using CM.WeeklyTeamReport.Domain;
using CM.WeeklyTeamReport.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CM.WeeklyTeamReport.Repositories.Tests
{
    public class TeamRepositoryTest
    {
        [Fact]
        public void ShouldBeAbleToWeeklyTeamRepository()
        {
            var teamRepository = new TeamRepository();
            teamRepository.Should().NotBeNull();
        }
        [Fact]
        public void ShouldBeAbleToAddTeam()
        {
            var teamRepository = new TeamRepository();
            var team = new Team(2, new HashSet<int> { 4 }, new HashSet<int> { 2 });
            var newTeam = teamRepository.Create(team);
            newTeam.MembersList[0].Should().Equals(team.MembersList[0]);
            newTeam.ReportsList[0].Should().Equals(newTeam.ReportsList[0]);
            newTeam.TeamNumber.Should().Equals(newTeam.TeamNumber);
        }
        [Fact]
        public void ShouldBeAbleToReadTeam()
        {
            var teamRepository = new TeamRepository();
            var readTeam = teamRepository.Read(1);
            readTeam.Should().NotBeNull();
        }
        [Fact]
        public void ShouldBeAbleToDeleteTeam()
        {
            var teamRepository = new TeamRepository();
            teamRepository.Delete(3);
            var deletedTeamMember = teamRepository.Read(3);
        }
        [Fact]
        public void ShouldBeAbleToUpdateTeam()
        {
            var teamRepository = new TeamRepository();
            var team = new Team(5, new HashSet<int> { 4 }, new HashSet<int> { 2 });
            teamRepository.Update(8, team);
            var updatedTeam = teamRepository.Read(5);
            updatedTeam.Should().NotBeNull();
            updatedTeam.MembersList[0].Should().Equals(team.MembersList[0]);
            updatedTeam.ReportsList[0].Should().Equals(team.ReportsList[0]);
            updatedTeam.TeamNumber.Should().Equals(team.TeamNumber);
        }
    }
}
