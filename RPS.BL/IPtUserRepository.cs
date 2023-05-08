using RPS.Core.Models;
using System.Collections.Generic;

namespace RPS.BL
{
    public interface IPtUserRepository
    {
        IEnumerable<PtUser> GetAll();
    }
}
