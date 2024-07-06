using Streaming.Domain.Admin.Aggregates;
using Streaming.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streaming.Repository.Repository
{
    public class UsuarioAdminRepository : RepositoryBase<UsuarioAdmin>
    {
        public UsuarioAdminRepository(StreamingAdminContext context) : base(context)
        {
        }
    }

}

