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
    public class ContactController : Controller
    {
        private ICompanµRepository _companyRepository;
        private IClientRepository _clientRepository;
        private IContactRepository _contactRepository;
        private IApplicationRepository _applicationrepository;

        public ContactController(ICompanµRepository companyRepo,
            IClientRepository clientRepo,
            IContactRepository contactRepo,
            IApplicationRepository applicationRepo)
        {
            _companyRepository = companyRepo;
            _clientRepository = clientRepo;
            _contactRepository = contactRepo;
            _applicationrepository = applicationRepo;
        }


        [HttpPost]
        public IActionResult Send([FromBody]Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            contact = new Contact
            {
                FirstName = contact.FirstName,
                Name = contact.Name,
                Telephone = contact.Telephone,
                Email = contact.Email,
                Project = contact.Project
            };

            _contactRepository.Add(contact);
            _contactRepository.Commit();

            // Ajouter un ViewModel plus tard

            return new NoContentResult();
        }
    }
}
