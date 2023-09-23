using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectChallengeData.Database.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        IClientRepository ClientRepository { get; }

        int Commit();
    }
}
