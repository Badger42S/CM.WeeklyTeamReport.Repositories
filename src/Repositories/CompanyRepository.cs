using CM.WeeklyTeamReport.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.WeeklyTeamReport.Repositories
{
    public class CompanyRepository : IRepository<Company>

    {
        public Company Create(Company company)
        {
            var connectionString = @"Server=localhost;Database=WeeklyTeamReport;Trusted_Connection=True;";
            using (var connection = new SqlConnection(connectionString))
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
                        (string)reader["City"], (string)reader["President"]);
                    return returnedCompany;
                }
            };

            return null;
        }
    }
}
