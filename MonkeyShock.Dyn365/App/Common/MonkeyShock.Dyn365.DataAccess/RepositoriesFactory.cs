using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;

namespace MonkeyShock.Dyn365.DataAccess
{
    public class RepositoriesFactory
    {
        private readonly IOrganizationService orgService; 
        public RepositoriesFactory(IOrganizationService orgService)
        {
            this.orgService = orgService; 
        }

        public RepositoriesFactory(CrmServiceClient crmServiceClient)
        {
            this.orgService =  crmServiceClient.OrganizationServiceProxy;
        }

        public T Get<T>() where T: RepositoryBase, new()
        {
            T repository = new T();
            repository.Initialize(this.orgService);
            return repository; 
        }
    }
}
