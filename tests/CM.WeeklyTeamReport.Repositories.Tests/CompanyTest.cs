using FluentAssertions;
using System;
using Xunit;

namespace CM.WeeklyTeamReport.Repositories.Tests
{
    public class CompanyTest
    {
        [Fact]
        public void ShouldBeAbleToCreateCompanyRepository()
        {
            var companyRepository = new CompanyRepository();
            companyRepository.Should().NotBeNull();
        }
        [Fact]
        public void ShouldBeAbleToCreateCompanyRepository()
        {
            var companyRepository = new CompanyRepository();
            companyRepository.Should().NotBeNull();
        }
    }
}
