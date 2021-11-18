using CM.WeeklyTeamReport.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.WeeklyTeamReport.Repositories
{
    public class TeamMemberRepository : ConnecorToRepository<TeamMember>
    {
        public override TeamMember Create(TeamMember entity)
        {
            using (var connection = connectionToDB())
            {
                connection.Open();
                var insertCommandString = @"INSERT INTO TeamMembers (CompanyId, FirstName, LastName, Role) 
VALUES (@CompanyId, @FirstName, @LastName, @Role); Select * from TeamMembers where TeamMemberId=SCOPE_IDENTITY()";
                var insertCommand = new SqlCommand(insertCommandString, connection);

                insertCommand.Parameters.AddWithValue("@CompanyId", entity.CompanyId);
                insertCommand.Parameters.AddWithValue("@FirstName", entity.FirstName);
                insertCommand.Parameters.AddWithValue("@LastName", entity.LastName);
                insertCommand.Parameters.AddWithValue("@Role", entity.Role);
                var reader = insertCommand.ExecuteReader();

                if (reader.Read())
                {
                    var returnedTeamMember = new TeamMember( (int)reader["TeamMemberId"], (int)reader["CompanyId"],
                        (string)reader["FirstName"], (string)reader["LastName"],
                        (Roles)reader["Role"]);
                    return returnedTeamMember;
                }
            };
            return null;
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override TeamMember Read(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(int id, TeamMember entity)
        {
            throw new NotImplementedException();
        }
    }
}
