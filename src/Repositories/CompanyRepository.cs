using CM.WeeklyTeamReport.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.WeeklyTeamReport.Repositories
{
    public class CompanyRepository : ConnecorToRepository<Company>

    {
        public override Company Create(Company company)
        {
            using (var connection = connectionToDB())
            {
                connection.Open();
                var insertCommandString = @"INSERT INTO Companies (CompanyName, Country, City, President) 
VALUES (@CompanyName, @Country, @City, @President); Select * from Companies where CompanyId=SCOPE_IDENTITY()";
                var insertCommand = new SqlCommand(insertCommandString, connection);

                insertCommand.Parameters.AddWithValue("@CompanyName", company.CompanyName);
                insertCommand.Parameters.AddWithValue("@Country", company.Country);
                insertCommand.Parameters.AddWithValue("@City", company.City);
                insertCommand.Parameters.AddWithValue("@President", company.President);
                var reader = insertCommand.ExecuteReader();

                if (reader.Read()) 
                {
                    var returnedCompany = new Company(
                        (string)reader["CompanyName"], (string)reader["Country"], 
                        (string)reader["City"], (string)reader["President"], (int)reader["CompanyId"]);
                    return returnedCompany;
                }
            };
            return null;
        }

        public override void Delete(int id)
        {
            using (var connection = connectionToDB())
            {
                connection.Open();
                var deleteCommandString = @"Delete from Companies where CompanyId=@SearchingId";
                var deleteCommand = new SqlCommand(deleteCommandString, connection);

                deleteCommand.Parameters.AddWithValue("@SearchingId", id);
                deleteCommand.ExecuteNonQuery();
            };
        }

        public override Company Read(int id)
        {
            using (var connection = connectionToDB())
            {
                connection.Open();
                var readCommandString = @"Select * from Companies where CompanyId=@SearchingId";
                var readCommand = new SqlCommand(readCommandString, connection);

                readCommand.Parameters.AddWithValue("@SearchingId", id);
                var reader = readCommand.ExecuteReader();

                if (reader.Read())
                {
                    var returnedCompany = new Company(
                        (string)reader["CompanyName"], (string)reader["Country"],
                        (string)reader["City"], (string)reader["President"], (int)reader["CompanyId"]);
                    return returnedCompany;
                }
            };

            return null;
        }

        public override void Update(int id, Company company)
        {
            using (var connection = connectionToDB())
            {
                connection.Open();
                var updateCommandString = @"Update Companies SET CompanyName=@CompanyName, Country=@Country, 
City=@City, President=@President where CompanyId=@UpdatingId";
                var updateCommand = new SqlCommand(updateCommandString, connection);

                updateCommand.Parameters.AddWithValue("@CompanyName", company.CompanyName);
                updateCommand.Parameters.AddWithValue("@Country", company.Country);
                updateCommand.Parameters.AddWithValue("@City", company.City);
                updateCommand.Parameters.AddWithValue("@President", company.President);
                updateCommand.Parameters.AddWithValue("@UpdatingId", id);
                updateCommand.ExecuteNonQuery();
            };
        }
    }
}
