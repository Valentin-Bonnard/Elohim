using Elohim.Data.Abstract;
using Elohim.Model.Entitµes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elohim.Data.Repositories
{
    public class ApplicationRepository : EntityBaseRepository<Application>, IApplicationRepository
    {
        public ApplicationRepository(ElohimContext context)
            : base(context) { }
    }
}
