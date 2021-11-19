using System;
using Xunit;

namespace CM.WeeklyTeamReport.Domain.Tests
{
    public class CompanyTest
    {
        [Fact]
        public void ShouldBeCompany()
        {
            string companyName = "Sega";
            string country = "Japan";
            string city = "Tokio";
            string president = "Hajime Satomi";
            var company = new Company(companyName, country, city, president, 8);
            Assert.NotNull(company);
            Assert.Equal("Sega", company.CompanyName);
            Assert.Equal("Japan", company.Country);
            Assert.Equal("Tokio", company.City);
            Assert.Equal("Hajime Satomi", company.President);
            Assert.Equal(8, company.CompanyId);
        }
        [Fact]
        public void ShouldBeNewPresident()
        {
            string companyName = "Sega";
            string country = "Japan";
            string city = "Tokio";
            string president = "Hajime Satomi";
            var company = new Company(companyName, country, city, president);
            Assert.Equal("Hajime Satomi", company.President);
            company.NewPresident("Hironobu Sakaguchi");
            Assert.Equal("Hironobu Sakaguchi", company.President);
        }
    }
}
