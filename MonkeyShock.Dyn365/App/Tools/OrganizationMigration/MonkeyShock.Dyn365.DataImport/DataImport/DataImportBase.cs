using MonkeyShock.DocumentDb.DataAccess;

namespace MonkeyShock.Dyn365.DataImport.DataImport
{
    public abstract class DataImportBase
    {
        protected readonly IDocDbUnitOfWork unitOfWork;
        public DataImportBase(IDocDbUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }
    }
}
