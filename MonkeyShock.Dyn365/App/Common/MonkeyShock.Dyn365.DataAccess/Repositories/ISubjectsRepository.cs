using System.Collections.Generic;
using MonkeyShock.Dyn365.Entities;

namespace MonkeyShock.Dyn365.DataAccess.Repositories
{
    public interface ISubjectsRepository : IRepositoryBase
    {
        IEnumerable<Subject> GetAllSubjects();
    }
}
