using Microsoft.AspNetCore.Mvc;
using ProjectChallengeDomain.IService;
using ProjectChallengeDomain.Models;
using ProjectChallengeDomain.Models.Requests;

namespace ProjectChallengeAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _serviceClient;
        public ClientController(IClientService serviceClient)
        {
            _serviceClient = serviceClient;

        }
        /// <summary>
        /// Get all clients
        /// </summary>
        /// <response code="200">List of all clients.</response>
        /// <response code="404">No clients found.</response>
        /// <response code="500">Error to get all clients.</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _serviceClient.Get();

            if (clients == null || clients.Count() == 0)
                return NotFound(new { message = "Clients not found." });
            return Ok(clients);
        }
        /// <summary>
        /// Get a client by Id
        /// </summary>
        /// <param name="id">Client Id.</param>
        /// <response code="200">The client from the id.</response>
        /// <response code="404">No client found.</response>
        /// <response code="500">Error to get the client.</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var client = await _serviceClient.GetById(id);

            if (client == null)
                return NotFound(new { message = "Client not found." });

            return Ok(client);
        }

        /// <summary>
        /// Creates a clinte.
        /// </summary>
        /// <param name="Client">Client data.</param>
        /// <returns>Client successfully created.</returns>
        /// <response code="200">Client object</response>
        /// <response code="400">Client data invalid.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost]
        public IActionResult CreateClient(ClientRequestPost Client)
        {
            var response = _serviceClient.Post(Client);
            return Ok(response);
        }
        /// <summary>
        /// Update client.
        /// </summary> 
        /// <param name="id">Client id to be updated.</param>
        /// <param name="Client">Client data.</param>
        /// <response code="200">Client successfully updated.</response>
        /// <response code="400">Client data invalid.</response>
        /// <response code="404">Client not found.</response>
        /// <response code="500">Error to update client.</response>
        [HttpPut]
        public async Task<IActionResult> UpdateClient(ClientRequestPut Client)
        {
            var response =await  _serviceClient.Put(Client);

            if (response == null)
                return NotFound(new { message = "Client not found." });

            return Ok(response);
        }
        /// <summary>
        /// Delete client.
        /// </summary>
        /// <param name="ClientId">Client id.</param>
        /// <response code="200">Client successfully deleted.</response>
        /// <response code="404">Client not found.</response>
        /// <response code="500">Error to delete client.</response>
        [HttpDelete]
        public async Task<IActionResult> DeleteClient(Guid clientId)
        {
            var response = await _serviceClient.Delete(clientId);
            if (!response)
                return NotFound(new { message = "Client not found." });
            return Ok(true);
        }
    }
}
