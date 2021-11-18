using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.WeeklyTeamReport.Repositories
{
    public abstract class ConnecorToRepository<T> : IRepository<T> where T : class
    {
        public abstract T Create(T entity);
        public abstract void Delete(int id);
        public abstract T Read(int id);
        public abstract void Update(int id, T entity);

        private const string connectionString = @"Server=localhost;Database=WeeklyTeamReport;Trusted_Connection=True;";
        public SqlConnection connectionToDB(string connectionString = connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}
