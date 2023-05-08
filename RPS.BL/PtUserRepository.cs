using RPS.Core.Models;
using System.Collections.Generic;

namespace RPS.BL
{
    public class PtUserRepository : IPtUserRepository
    {
        private PtInMemoryContext context;

        public PtUserRepository(PtInMemoryContext context)
        {
            this.context = context;
        }

        public IEnumerable<PtUser> GetAll()
        {
            return context.PtUsers;
        }
    }
}
