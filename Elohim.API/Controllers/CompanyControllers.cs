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
    public class CompanyControllers : Controller
    {
        private ICompanµRepository _companyRepository;
        private IClientRepository _clientRepository;
        private IContactRepository _contactRepository;
        private IApplicationRepository _applicationrepository;

        public CompanyControllers(ICompanµRepository companyRepo,
            IClientRepository clientRepo,
            IContactRepository contactRepo,
            IApplicationRepository applicationRepo)
        {
            _companyRepository = companyRepo;
            _clientRepository = clientRepo;
            _contactRepository = contactRepo;
            _applicationrepository = applicationRepo;
        }

        [HttpGet("{id}", Name = "GetCompany")]
        public  IActionResult Get()
        {
            var company = _companyRepository.Getall().ToList();

            if(company != null)
            {
                return Ok();
            }else
            {
                return NotFound();
            }
        }
    }
}
