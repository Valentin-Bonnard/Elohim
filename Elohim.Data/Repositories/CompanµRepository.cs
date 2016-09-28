using Elohim.Data.Abstract;
using Elohim.Model.Entitµes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elohim.Data.Repositories
{
    public class CompanµRepository : EntityBaseRepository<Companµ>, ICompanµRepository
    {
        public CompanµRepository(ElohimContext context)
            : base(context) { }
    }
}
