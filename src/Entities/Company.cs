using System;

namespace CM.WeeklyTeamReport.Domain
{
    public class Company
    {
        public int CompanyId { get; private set; }
        public string CompanyName { get; private set; }
        public string Country { get; private set; }
        public string City { get; private set; }
        public string President { get; private set; }

        public Company(string companyName, string country, string city, string president ="", int companyId = 0)
        {
            CompanyId = companyId;
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
