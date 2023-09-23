using ProjectChallengeDomain.Models;
using ProjectChallengeDomain.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectChallengeDomain.IService
{
    public interface IClientService
    {
        Client Post(ClientRequestPost request);
        Task<Client> Put(ClientRequestPut request);
        Task<List<Client>> Get();
        Task<Client> GetById(Guid id);

        Task<bool> Delete(Guid id);
    }
}
