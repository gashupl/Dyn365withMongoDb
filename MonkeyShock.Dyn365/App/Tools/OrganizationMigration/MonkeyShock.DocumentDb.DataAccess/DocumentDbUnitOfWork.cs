using MongoDB.Driver;

namespace MonkeyShock.DocumentDb.DataAccess
{
    public class DocumentDbUnitOfWork : IDocDbUnitOfWork
    {
        public DocumentDbUnitOfWork(IMongoDatabase documentDb)
        {
            this.SubjectsRepository = new SubjectsRepository(documentDb); 
        }

        public IDocDbSubjectsRepository SubjectsRepository { get; }
    }
}
