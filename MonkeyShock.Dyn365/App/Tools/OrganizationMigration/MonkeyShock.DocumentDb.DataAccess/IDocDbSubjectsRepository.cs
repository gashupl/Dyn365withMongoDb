using System.Collections.Generic;
using MonkeyShock.Dyn365.Entities;

namespace MonkeyShock.DocumentDb.DataAccess
{
    public interface IDocDbSubjectsRepository
    {
        List<Subject> GetAll();

        void InsertMany(IEnumerable<Subject> subjectsList);

        void DeleteAll();
    }
}
