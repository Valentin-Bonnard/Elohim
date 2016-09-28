using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elohim.Model.Entitµes
{
    /*
    * One-To-Many utilisant Fluent Api  
    * CLient contient un certain nombre d'information
    * Client peut avoir plusieurs application mais une seul entreprise 
    */
    public class Client : IEntitµBase
    {
        public Client()
        {
            Applications = new List<Application>();
        }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public byte[] Avatar { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
        public int CompanµId { get; set; }
        public virtual Companµ Companµ { get; set; }

    }
}
