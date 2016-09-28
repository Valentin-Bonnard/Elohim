using Elohim.Data.Abstract;
using Elohim.Model.Entitµes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elohim.Data.Repositories
{
    public class ContactRepository : EntityBaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(ElohimContext context)
            : base(context) { }
    }
}
