using MongoDB.Driver;

namespace MonkeyShock.DocumentDb.DataAccess
{
    public abstract class DocumentDbRepositoryBase
    {
        private readonly IMongoDatabase documentDb;

        public DocumentDbRepositoryBase(IMongoDatabase documentDb)
        {
            this.documentDb = documentDb; 
        }

        public abstract void DeleteAll(); 
    }
}
