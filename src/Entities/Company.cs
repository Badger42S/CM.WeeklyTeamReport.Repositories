using System;

namespace CM.WeeklyTeamReport.Domain
{
    public class Company
    {
        public string CompanyName { get; set; }
        public string Country { get; set; }
        public string City { get; }
        public string President { get; private set; }

        public Company(string companyName, string country, string city, string president)
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
