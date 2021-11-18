using CM.WeeklyTeamReport.Domain;
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
        public void ShouldBeAbleToAddCompany()
        {
            var companyRepository = new CompanyRepository();
            var company = new Company("Sony", "Japan", "Tokio", "Pelevin");
            var newCompany = companyRepository.Create(company);
            newCompany.CompanyName.Should().BeEquivalentTo(company.CompanyName);
            newCompany.Country.Should().BeEquivalentTo(company.Country);
            newCompany.City.Should().BeEquivalentTo(company.City);
            newCompany.President.Should().BeEquivalentTo(company.President);
        }
    }
}
