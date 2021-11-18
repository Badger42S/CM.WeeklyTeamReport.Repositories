using CM.WeeklyTeamReport.Domain;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CM.WeeklyTeamReport.Repositories.Tests
{
    public class WeeklyReportRepositoryTest
    {
        [Fact]
        public void ShouldBeAbleToWeeklyReportRepository()
        {
            var weeklyReportRepository = new WeeklyReportRepository();
            weeklyReportRepository.Should().NotBeNull();
        }
        [Fact]
        public void ShouldBeAbleToAddWeeklyReport()
        {
            var weeklyReportRepository = new WeeklyReportRepository();
            var weeklyReport = new WeeklyReport(DayOfWeek.Tuesday, 5, "important task");
            var newWeeklyReport = weeklyReportRepository.Create(weeklyReport);
            newWeeklyReport.DateStart.Should().Equals(weeklyReport.DateStart);
            newWeeklyReport.Duration.Should().Equals(weeklyReport.Duration);
            newWeeklyReport.Task.Should().Equals(weeklyReport.Task);
            newWeeklyReport.WeeklyReportId.Should().Equals(weeklyReport.WeeklyReportId);
        }
        [Fact]
        public void ShouldBeAbleToReadWeeklyReport()
        {
            var weeklyReportRepository = new WeeklyReportRepository();
            var readWeeklyReport = weeklyReportRepository.Read(3);
            readWeeklyReport.WeeklyReportId.Should().Equals(3);
            readWeeklyReport.Task.Should().NotBeEmpty();
            readWeeklyReport.Duration.Should().BeGreaterThan(0);
            readWeeklyReport.DateStart.HasFlag(DayOfWeek.Thursday);
        }
        [Fact]
        public void ShouldBeAbleToUpdateWeeklyReport()
        {
            var weeklyReportRepository = new WeeklyReportRepository();
            var readdWeeklyReport = weeklyReportRepository.Read(4);
            readdWeeklyReport.Duration += 1;
            weeklyReportRepository.Update(readdWeeklyReport.WeeklyReportId, readdWeeklyReport);
            var updatedWeeklyReport = weeklyReportRepository.Read(readdWeeklyReport.WeeklyReportId);
            updatedWeeklyReport.Should().NotBeNull();
            updatedWeeklyReport.Task.Should().Equals(readdWeeklyReport.Task);
            updatedWeeklyReport.Duration.Should().Equals(readdWeeklyReport.Duration + 1);
            updatedWeeklyReport.WeeklyReportId.Should().Equals(readdWeeklyReport.WeeklyReportId);
            updatedWeeklyReport.DateStart.Should().Equals(readdWeeklyReport.DateStart);
        }
        [Fact]
        public void ShouldBeAbleToDeleteWeeklyReport()
        {
            var weeklyReportRepository = new WeeklyReportRepository();
            var deletedTeamMember = weeklyReportRepository.Read(4);
            deletedTeamMember.Should().NotBeNull();
            weeklyReportRepository.Delete(4);
            deletedTeamMember = weeklyReportRepository.Read(4);
            deletedTeamMember.Should().BeNull();
        }
    }
}
