using Elohim.API.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elohim.API.Extensions
{
    /*
     * Pagination dans le header et si le client veut retrouver une info sure la page
     * deux , il s'affichera 2, quelque chosse
     * Pour les messages d'erreur que retourne le serveur au client, idem que la
     * pagination = request/response header.    
     */
    public static class Extensions
    {
        public static void AddPagination(this HttpResponse response, int currentPage, int itemsPerPage, int totalItems, int totalPages)
        {
            var pagination = new Pagination(currentPage, itemsPerPage, totalItems, totalPages);

            response.Headers.Add("Pagination",
                Newtonsoft.Json.JsonConvert.SerializeObject(pagination));
            // CORS
            response.Headers.Add("acces-control-expose-headers", "Pagination");
        }
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);

            // CORS
            response.Headers.Add("acces-control-expose-headers", "Application-Error");
        }
    }
}
