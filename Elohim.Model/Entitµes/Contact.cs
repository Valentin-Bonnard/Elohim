﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elohim.Model.Entitµes
{
    public class Contact : IEntitµBase
    {
        /*
        * One-To-Many utilisant Fluent Api  
        * Contact contient un certain nombre d'information
        * Contact ne demande qu'a une seul entreprise
        */
        public Contact() { }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Project { get; set; }

        public int CompanµId { get; set; }
        public virtual Companµ Companµ { get; set; }

    }
}
