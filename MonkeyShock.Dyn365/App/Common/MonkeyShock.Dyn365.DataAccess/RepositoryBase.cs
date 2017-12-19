using System;
using Microsoft.Xrm.Sdk;
using MonkeyShock.Dyn365.Entities;

namespace MonkeyShock.Dyn365.DataAccess
{
    public abstract class RepositoryBase : IRepositoryBase
    {
        protected Dyn365ServiceContext serviceContext;
        protected IOrganizationService orgService; 

        public void Initialize(IOrganizationService orgService)
        {
            this.orgService = orgService;
            this.serviceContext = new Dyn365ServiceContext(orgService); 
        }
        public Entity GetById(Guid id, string entityLogicalName)
        {
            throw new NotImplementedException();
        }

        public Guid Create(Entity entity)
        {
            return this.orgService.Create(entity); 
        }

        public void Update(Entity entity)
        {
            this.orgService.Update(entity); 
        }
    }
}
