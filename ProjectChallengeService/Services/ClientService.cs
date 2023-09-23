using ProjectChallengeData.Database.Repositories.IRepositories;
using ProjectChallengeDomain.IService;
using ProjectChallengeDomain.Models;
using ProjectChallengeDomain.Models.Requests;
using System.Linq;

namespace ProjectChallengeService.Services
{
    public class ClientService : IClientService
    {
        private static IUnitOfWork _unitOfWork;


        public ClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Delete(Guid id)
        {
            var client = await _unitOfWork.ClientRepository.GetById(id);
            if (client is null)
                return false;

            _unitOfWork.ClientRepository.Remove(client);
            _unitOfWork.Commit();

            return true;
        }

        public async Task<List<Client>> Get()
        {
            var clientes = await _unitOfWork.ClientRepository.GetAll();
            return clientes.ToList();
        }

        public async Task<Client> GetById(Guid id)
        {
            return await _unitOfWork.ClientRepository.GetById(id);    
        }

        public Client Post(ClientRequestPost request)
        {
            Client client = new Client();
            client.Name = request.Name;
            client.Age = request.Age;
            _unitOfWork.ClientRepository.Add(client);
            _unitOfWork.Commit();
            return client;
        }

        public async Task<Client> Put(ClientRequestPut request)
        {
            var client = await _unitOfWork.ClientRepository.GetById(request.Id);
            if (client is null)
                return null;

            client.UpdateDate = DateTime.UtcNow.AddHours(-3);
            client.Name = request.Name;
            client.Age = request.Age;
            _unitOfWork.ClientRepository.Update(client);
            _unitOfWork.Commit();
            return client;
        }
    }
}
