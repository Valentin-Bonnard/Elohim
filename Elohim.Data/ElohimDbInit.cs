using Elohim.Model.Entitµes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elohim.Data
{
    public class ElohimDbInit
    {
        private static ElohimContext context;
        public static void Initializer(IServiceProvider serviceProvider)
        {
            context = (ElohimContext)serviceProvider.GetService(typeof(ElohimContext));

            InitElohim();
        }

        /*
         * Populé la base a la premiere compilation (cf : starup.cs) 
         */

        private static void InitElohim()
        {
            #region populé Client

            if (!context.ClientSet.Any())
            {
                Client client_01 = new Client
                {
                    ID = 1,
                    FirstName = "Barry",
                    Name = "Allen",
                    Country = "Usa",
                    City = "Central City",
                    Address = "Main Street",
                    Telephone = "(+33) 4 58 770 21 65",
                    Email = "Flash@gmail.com",
                    Applications = new List<Application>
                    {
                        new Application()  { ID = 1 }
                    }
                };

                Client client_02 = new Client
                {
                    ID = 2,
                    FirstName = "Bruce",
                    Name = "Wayne",
                    Country = "Usa",
                    City = "Gotham City",
                    Address = "Third Street",
                    Telephone = "78 735 32",
                    Email = "Batman@gmail.com",
                    Applications = new List<Application>
                    {
                        new Application() {ID = 2 }
                    }
                };

                context.ClientSet.Add(client_01); context.ClientSet.Add(client_02);

                context.SaveChanges();
            }

            #endregion

            #region populé Application

            if (!context.ApplicationSet.Any())
            {
                Application app_01 = new Application { ID = 1, Name = "Flash Module", Android = "https://android.com", Ios = "https://apple.ios.com", ClientId = 1, Description = "Ceci est un project pour Flash" };

                Application app_02 = new Application { ID = 2, Name = "Finder Badguy", Android = "https://android.com", Ios = "https://apple.ios.com", ClientId = 2, Description = "Ceci est un project pour Batman" };

                context.ApplicationSet.Add(app_01); context.ApplicationSet.Add(app_02);

                context.SaveChanges();
            }
            #endregion

            #region populé Contact

            if (!context.ContactSet.Any())
            {
                Contact contact_01 = new Contact { ID = 1, FirstName = "Clark", Name = "Kent", Telephone = "451 54 55 236", Email = "Superman@gmail.com", Project = "Ceci est un project pour Superman" };

                context.ContactSet.Add(contact_01);

                context.SaveChanges();
            }

            #endregion

            #region populé Comapny

            if (!context.CompanµSet.Any())
            {
                Companµ companµ = new Companµ
                {
                    Name = "Test",
                    Country = "France",
                    City = "Lille",
                    Address = "rue du test",
                    Applications = new List<Application>
                {
                    new Application() { ID = 1 },
                    new Application() { ID = 2 }
                },
                    Clients = new List<Client>
                    {
                        new Client() {ID = 1 },
                        new Client() {ID = 2 }
                    }
                };

                context.CompanµSet.Add(companµ);

                context.SaveChanges();
            }

            #endregion
        }
    }
}
