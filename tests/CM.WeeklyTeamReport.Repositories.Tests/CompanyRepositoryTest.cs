using CM.WeeklyTeamReport.Domain;
using FluentAssertions;
using System;
using Xunit;

namespace CM.WeeklyTeamReport.Repositories.Tests
{
    public class CompanyRepositoryTest
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
            newCompany.CompanyName.Should().Equals(company.CompanyName);
            newCompany.Country.Should().Equals(company.Country);
            newCompany.City.Should().Equals(company.City);
            newCompany.President.Should().Equals(company.President);
        }
        [Fact]
        public void ShouldBeAbleToReadCompany()
        {
            var companyRepository = new CompanyRepository();
            var readCompany = companyRepository.Read(3);
            readCompany.CompanyId.Should().Equals(3);
            readCompany.Country.Should().NotBeEmpty();
            readCompany.City.Should().NotBeEmpty();
            readCompany.President.Should().NotBeEmpty();
        }
        [Fact]
        public void ShouldBeAbleToDeleteCompany()
        {
            var companyRepository = new CompanyRepository();
            var deletedCompany = companyRepository.Read(2);
            deletedCompany.Should().NotBeNull();
            companyRepository.Delete(2);
            deletedCompany = companyRepository.Read(2);
            deletedCompany.Should().BeNull();
        }
        [Fact]
        public void ShouldBeAbleToUpdateCompany()
        {
            var companyRepository = new CompanyRepository();
            var company = new Company("Sony", "Japan", "Tokio", "Pelevin", 3);
            companyRepository.Update(company.CompanyId, company);
            var updatedCompany = companyRepository.Read(company.CompanyId);
            updatedCompany.Should().NotBeNull();
            updatedCompany.CompanyName.Should().Equals(company.CompanyName);
            updatedCompany.Country.Should().Equals(company.Country);
            updatedCompany.City.Should().Equals(company.City);
            updatedCompany.President.Should().Equals(company.President);
        }
    }
}
