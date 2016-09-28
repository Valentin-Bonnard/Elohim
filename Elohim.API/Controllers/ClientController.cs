using Elohim.API.Extensions;
using Elohim.Data.Abstract;
using Elohim.Model.Entitµes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elohim.API.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private ICompanµRepository _companyRepository;
        private IClientRepository _clientRepository;
        private IContactRepository _contactRepository;
        private IApplicationRepository _applicationrepository;
        Application app;

        public ClientController(ICompanµRepository companyRepo,
            IClientRepository clientRepo,
            IContactRepository contactRepo,
            IApplicationRepository applicationRepo)
        {
            _companyRepository = companyRepo;
            _clientRepository = clientRepo;
            _contactRepository = contactRepo;
            _applicationrepository = applicationRepo;
        }
        

        [HttpGet("{id}/client", Name = "GetClient")]
        public IActionResult GetClient(int id)
        {
            Client _client = _clientRepository.GetSingle(c => c.ID == id);

            if(_client != null)
            {
                return Ok();
            }else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}/clientapp", Name = "GetAppFromClient")]
        public IActionResult GetAppFromClient(int id)
        {
            IEnumerable<Application> _app = _applicationrepository.FindBy(a => a.ClientId == id);

            if (_app != null)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


        [HttpGet("clientapp", Name = "GetappClientt")]
        public IActionResult GetappClient()
        {
           
            IEnumerable<Client> _client = _clientRepository.Getall().Where(c => c.ID == app.ClientId);
           
            if (_client != null)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}

