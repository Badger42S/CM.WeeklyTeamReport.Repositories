using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.WeeklyTeamReport.Repositories
{
    interface IRepository<T>
    {
        public T Create(T entity);
        public T Read(int id);
        public void Update(int id, T entity);
        public void Delete(int id);
    }
}
