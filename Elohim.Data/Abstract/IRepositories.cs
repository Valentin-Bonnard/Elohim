using Elohim.Model.Entitµes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elohim.Data.Abstract
{
    public interface ICompanµRepository : IEntityBaseRepository<Companµ> { }
    public interface IClientRepository : IEntityBaseRepository<Client> { }
    public interface IApplicationRepository : IEntityBaseRepository<Application> { }
    public interface IContactRepository : IEntityBaseRepository<Contact> { }
}
