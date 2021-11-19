using CM.WeeklyTeamReport.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace CM.WeeklyTeamReport.Domain.Tests
{
    public class TeamsTest
    {
        [Fact]
        public void ShouldBeWeeklyReport()
        {
            var team = new Team(7, new HashSet<int>() {5}, new HashSet<int>() { 6 }, 9);
            Assert.NotNull(team);
            Assert.Equal(9, team.Id);
            Assert.Equal(7, team.TeamNumber);
            Assert.Equal(5, team.MembersList[0]);
            Assert.Equal(6, team.ReportsList[0]);
        }
    }
}
