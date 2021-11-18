using CM.WeeklyTeamReport.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.WeeklyTeamReport.Repositories
{
    public class WeeklyReportRepository : ConnecorToRepository<WeeklyReport>
    {
        public override WeeklyReport Create(WeeklyReport entity)
        {
            using (var connection = connectionToDB())
            {
                connection.Open();
                var insertCommandString = @"INSERT INTO WeeklyReports (DateStart, Duration, Task) 
VALUES (@DateStart, @Duration, @Task); Select * from WeeklyReports where WeeklyReportId=SCOPE_IDENTITY()";
                var insertCommand = new SqlCommand(insertCommandString, connection);

                insertCommand.Parameters.AddWithValue("@DateStart", entity.DateStart);
                insertCommand.Parameters.AddWithValue("@Duration", entity.Duration);
                insertCommand.Parameters.AddWithValue("@Task", entity.Task);
                var reader = insertCommand.ExecuteReader();

                if (reader.Read())
                {
                    var returnedWeeklyReport = new WeeklyReport(
                        (DayOfWeek)reader["DateStart"], (double)reader["Duration"],
                        (string)reader["Task"], (int)reader["WeeklyReportId"]);
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
                var deleteCommandString = @"Delete from WeeklyReports where WeeklyReportId=@SearchingId";
                var deleteCommand = new SqlCommand(deleteCommandString, connection);

                deleteCommand.Parameters.AddWithValue("@SearchingId", id);
                deleteCommand.ExecuteNonQuery();
            };
        }

        public override WeeklyReport Read(int id)
        {
            using (var connection = connectionToDB())
            {
                connection.Open();
                var readCommandString = @"Select * from WeeklyReports where WeeklyReportId=@SearchingId";
                var readCommand = new SqlCommand(readCommandString, connection);

                readCommand.Parameters.AddWithValue("@SearchingId", id);
                var reader = readCommand.ExecuteReader();

                if (reader.Read())
                {
                    var returnedWeeklyReport = new WeeklyReport(
                        (DayOfWeek)reader["DateStart"], (double)reader["Duration"],
                        (string)reader["Task"], (int)reader["WeeklyReportId"]);
                    return returnedWeeklyReport;
                }
            };

            return null;
        }

        public override void Update(int id, WeeklyReport entity)
        {
            using (var connection = connectionToDB())
            {
                connection.Open();
                var updateCommandString = @"Update WeeklyReports SET DateStart=@DateStart, Duration=@Duration, 
Task=@Task where WeeklyReportId=@UpdatingId";
                var updateCommand = new SqlCommand(updateCommandString, connection);

                updateCommand.Parameters.AddWithValue("@DateStart", entity.DateStart);
                updateCommand.Parameters.AddWithValue("@Duration", entity.Duration);
                updateCommand.Parameters.AddWithValue("@Task", entity.Task);
                updateCommand.Parameters.AddWithValue("@UpdatingId", id);
                updateCommand.ExecuteNonQuery();
            };
        }
    }
}
