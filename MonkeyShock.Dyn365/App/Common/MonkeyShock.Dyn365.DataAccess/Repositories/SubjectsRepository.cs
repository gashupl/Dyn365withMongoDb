using System.Collections.Generic;
using System.Linq;
using MonkeyShock.Dyn365.Entities;

namespace MonkeyShock.Dyn365.DataAccess.Repositories
{
    public class SubjectsRepository : RepositoryBase, ISubjectsRepository
    {
        public IEnumerable<Subject> GetAllSubjects()
        {
            var query = from p in this.serviceContext.SubjectSet
                select p;
            return query.AsEnumerable<Subject>();
        }
    }
}
