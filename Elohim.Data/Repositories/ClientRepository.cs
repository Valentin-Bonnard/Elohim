using Elohim.Data.Abstract;
using Elohim.Model.Entitµes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elohim.Data.Repositories
{
    public class ClientRepository : EntityBaseRepository<Client>, IClientRepository
    {
        public ClientRepository(ElohimContext context)
            : base(context) { }
    }
}
