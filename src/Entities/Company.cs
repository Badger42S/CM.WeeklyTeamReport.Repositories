using System;

namespace CM.WeeklyTeamReport.Domain
{
    public class Company
    {
        public string CompanyName { get; private set; }
        public string Country { get; private set; }
        public string City { get; private set; }
        public string President { get; private set; }

        public Company(string companyName, string country, string city, string president ="")
        {
            CompanyName = companyName;
            Country = country;
            City = city;
            President = president;
        }
        public void NewPresident(string newPresident)
        {
            President = newPresident;
        }
    }
}
