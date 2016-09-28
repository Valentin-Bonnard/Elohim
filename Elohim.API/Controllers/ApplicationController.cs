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
    public class ApplicationController : Controller
    {
        private ICompanµRepository _companyRepository;
        private IClientRepository _clientRepository;
        private IContactRepository _contactRepository;
        private IApplicationRepository _applicationRepository;

        public ApplicationController(ICompanµRepository companyRepo,
            IClientRepository clientRepo,
            IContactRepository contactRepo,
            IApplicationRepository applicationRepo)
        {
            _companyRepository = companyRepo;
            _clientRepository = clientRepo;
            _contactRepository = contactRepo;
            _applicationRepository = applicationRepo;
        }

        [HttpGet("{id}/application", Name = "GetApplication")]
        public IActionResult GetApplication(int id)
        {
            IEnumerable<Application> _app = _applicationRepository.FindBy(a => a.ID == id);

            if (_app != null)
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

