using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.WeeklyTeamReport.Domain
{
    public enum Roles
    {
        junior,
        middle,
        leader,
        manager
    }
    public class TeamMember
    {   
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int CompanyId { get; private set; }
        public Roles Role { get; set; }

        public TeamMember(int companyId, string firstName, string lastName, Roles role)
        {
            CompanyId = companyId;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
        }
    }
}
