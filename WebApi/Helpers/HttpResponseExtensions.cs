using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebApi.Helpers
{
    public static class HttpResponseExtensions
    {
        public static void AddPagination(this HttpResponse response, int currentPage, int itemsPerPage, int totalItems, int totalPages)
        {
            var paginationSettingsHeader = new PaginationSettingsHeader(currentPage, itemsPerPage, totalItems, totalPages);

            var camlerCaseFormatter = new JsonSerializerSettings();
            camlerCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();

            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationSettingsHeader, camlerCaseFormatter));
            response.Headers.Add("Acces-Control-Expose-Headers", "Pagination");
        }
    }
}