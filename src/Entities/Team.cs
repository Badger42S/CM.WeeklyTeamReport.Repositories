using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.WeeklyTeamReport.Entities
{
    public class Team
    {
        public int Id { get; private set; }
        public int TeamNumber{ get; private set; }
        private HashSet<int> _members;
        public HashSet<int> Members { 
            get { return _members; } 
            set {
                _members = value;
                MembersList = _members.ToList();
            }
        }
        public List<int> MembersList { get; set; }
        private HashSet<int> _reports;
        public HashSet<int> Reports
        {
            get { return _reports; }
            set
            {
                _reports = value;
                ReportsList = _reports.ToList();
            }
        }
        public List<int> ReportsList { get; set; }
        public Team(int teamNumber, HashSet<int> members, HashSet<int> reports, int id = 0)
        {
            Id = id;
            TeamNumber = teamNumber;
            Members = members;
            Reports = reports;
        }

    }
}
