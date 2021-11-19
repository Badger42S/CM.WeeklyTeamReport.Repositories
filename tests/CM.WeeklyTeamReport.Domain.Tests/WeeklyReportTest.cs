using System;
using Xunit;


namespace CM.WeeklyTeamReport.Domain.Tests
{
    public class WeeklyReportTest
    {
        [Fact]
        public void ShouldBeWeeklyReport()
        {
            var dateStart = DayOfWeek.Tuesday;
            double duration = 5;
            string task = "do nothing";
            WeeklyReport weeklyReport = new WeeklyReport(dateStart, duration, task, 7);
            Assert.NotNull(weeklyReport);
            Assert.Equal(DayOfWeek.Tuesday, weeklyReport.DateStart);
            Assert.Equal(5, weeklyReport.Duration);
            Assert.Equal("do nothing", weeklyReport.Task);
            Assert.Equal(7, weeklyReport.WeeklyReportId);
        }
    }
}
