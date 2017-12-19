using System.Collections.Generic;
using MongoDB.Driver;
using MonkeyShock.Dyn365.Entities;

namespace MonkeyShock.DocumentDb.DataAccess
{
    public class SubjectsRepository : DocumentDbRepositoryBase, IDocDbSubjectsRepository
    {
        readonly IMongoCollection<Subject> dataCollection;
        public SubjectsRepository(IMongoDatabase documentDb) : base(documentDb)
        {
            this.dataCollection = documentDb.GetCollection<Subject>("Subject");
        }

        public List<Subject> GetAll()
        {
            return this.dataCollection.Find<Subject>(Builders<Subject>.Filter.Empty).ToList<Subject>();
        }

        public void InsertMany(IEnumerable<Subject> subjectsList)
        {
            this.dataCollection.InsertMany(subjectsList);
        }

        public override void DeleteAll()
        {
            this.dataCollection.DeleteMany(s => true);
        }
    }
}
