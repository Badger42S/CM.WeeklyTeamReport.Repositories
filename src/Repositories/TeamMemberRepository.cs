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
            using (var connection = connectionToDB())
            {
                connection.Open();
                var deleteCommandString = @"Delete from TeamMembers where TeamMemberId=@SearchingId";
                var deleteCommand = new SqlCommand(deleteCommandString, connection);

                deleteCommand.Parameters.AddWithValue("@SearchingId", id);
                deleteCommand.ExecuteNonQuery();
            };
        }

        public override TeamMember Read(int id)
        {
            using (var connection = connectionToDB())
            {
                connection.Open();
                var readCommandString = @"Select * from TeamMembers where TeamMemberId=@SearchingId";
                var readCommand = new SqlCommand(readCommandString, connection);

                readCommand.Parameters.AddWithValue("@SearchingId", id);
                var reader = readCommand.ExecuteReader();

                if (reader.Read())
                {
                    var returnedTeamMember = new TeamMember((int)reader["TeamMemberId"], (int)reader["CompanyId"],
                       (string)reader["FirstName"], (string)reader["LastName"],
                       (Roles)reader["Role"]);
                    return returnedTeamMember;
                }
            };

            return null;
        }

        public override void Update(int id, TeamMember entity)
        {
            using (var connection = connectionToDB())
            {
                connection.Open();
                var updateCommandString = @"Update TeamMembers SET CompanyId=@CompanyId, FirstName=@FirstName, 
LastName=@LastName, Role=@Role where TeamMemberId=@UpdatingId";
                var updateCommand = new SqlCommand(updateCommandString, connection);

                updateCommand.Parameters.AddWithValue("@CompanyId", entity.CompanyId);
                updateCommand.Parameters.AddWithValue("@FirstName", entity.FirstName);
                updateCommand.Parameters.AddWithValue("@LastName", entity.LastName);
                updateCommand.Parameters.AddWithValue("@Role", entity.Role);
                updateCommand.Parameters.AddWithValue("@UpdatingId", id);
                updateCommand.ExecuteNonQuery();
            };
        }
    }
}
