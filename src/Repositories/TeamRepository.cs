using CM.WeeklyTeamReport.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.WeeklyTeamReport.Repositories
{
    public class TeamRepository : ConnecorToRepository<Team>
    {
        public override Team Create(Team entity)
        {
            using (var connection = connectionToDB())
            {
                connection.Open();
                var insertCommandString = @"INSERT INTO Teams (TeamNumber, TeamMember, WeeklyReport) 
VALUES (@TeamNumber, @TeamMember, @WeeklyReport); Select * from Teams where Id=SCOPE_IDENTITY()";
                var insertCommand = new SqlCommand(insertCommandString, connection);
                
                insertCommand.Parameters.AddWithValue("@TeamNumber", entity.TeamNumber);
                insertCommand.Parameters.AddWithValue("@TeamMember", entity.MembersList[0]);
                insertCommand.Parameters.AddWithValue("@WeeklyReport", entity.ReportsList[0]);
                var reader = insertCommand.ExecuteReader();

                if (reader.Read())
                {
                    var returnedWeeklyReport = new Team(
                         (int)reader["TeamNumber"], new HashSet<int> { (int)reader["TeamMember"] },
                         new HashSet<int> { (int)reader["WeeklyReport"] }, (int)reader["Id"]);
                    return returnedWeeklyReport;
                }
            };
            return null;
        }

        public override void Delete(int id)
        {
            using (var connection = connectionToDB())
            {
                connection.Open();
                var deleteCommandString = @"Delete from Teams where TeamNumber=@SearchingId";
                var deleteCommand = new SqlCommand(deleteCommandString, connection);

                deleteCommand.Parameters.AddWithValue("@SearchingId", id);
                deleteCommand.ExecuteNonQuery();
            };
        }

        public override Team Read(int teamNumberId)
        {
            using (var connection = connectionToDB())
            {
                connection.Open();
                var readCommandString = @"Select * from Teams where TeamNumber=@SearchingId";
                var readCommand = new SqlCommand(readCommandString, connection);
                readCommand.Parameters.AddWithValue("@SearchingId", teamNumberId);
                var reader = readCommand.ExecuteReader();
                var readTeam = new Team(teamNumberId, new HashSet<int> { }, new HashSet<int> { });
                while (reader.Read())
                {
                    var teamMemberId = (int)reader["TeamMember"];
                    var weeklyReportId = (int)reader["WeeklyReport"];
                    readTeam.Members.Add(teamMemberId);
                    readTeam.Reports.Add(weeklyReportId);
                }
                var returnedTeam = new Team(teamNumberId, new HashSet<int> (readTeam.Members), new HashSet<int>(readTeam.Reports));
                return returnedTeam;
            };

            return null;
        }

        public override void Update(int id, Team entity)
        {
            using (var connection = connectionToDB())
            {
                connection.Open();
                var updateCommandString = @"Update Teams SET TeamNumber=@TeamNumber, TeamMember=@TeamMember, 
WeeklyReport=@WeeklyReport where Id=@UpdatingId";
                var updateCommand = new SqlCommand(updateCommandString, connection);

                updateCommand.Parameters.AddWithValue("@TeamNumber", entity.TeamNumber);
                updateCommand.Parameters.AddWithValue("@TeamMember", entity.MembersList[0]);
                updateCommand.Parameters.AddWithValue("@WeeklyReport", entity.ReportsList[0]);
                updateCommand.Parameters.AddWithValue("@UpdatingId", id);
                updateCommand.ExecuteNonQuery();
            };
        }
    }
}
