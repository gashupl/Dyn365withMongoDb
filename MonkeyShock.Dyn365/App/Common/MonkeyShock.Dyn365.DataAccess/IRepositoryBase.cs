using System;
using Microsoft.Xrm.Sdk;

namespace MonkeyShock.Dyn365.DataAccess
{
    public interface IRepositoryBase
    {
        Entity GetById(Guid id, string entityLogicalName);

        Guid Create(Entity entity);

        void Update(Entity entity); 
    }
}
