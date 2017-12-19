using MonkeyShock.DocumentDb.DataAccess;

namespace MonkeyShock.Dyn365.DataExport.DataExports
{
    public abstract class DataExportBase
    {
        protected readonly DocumentDbUnitOfWork unitOfWork; 
        public DataExportBase(DocumentDbUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }

    }
}
