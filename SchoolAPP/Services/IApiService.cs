using SchoolAPP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolAPP.Services
{
    public interface IApiService
    {
        Task<Response> GetMultipleResultsAsync<T>(string urlBase, string servicePrefix, string controller, string tokenType, string accessToken);
        Task<Response> GetSingleResultAsync<T>(string urlBase, string servicePrefix, string controller, string tokenType, string accessToken);
        Task<Response> GetTokenAsync(string urlBase, string controller, TokenRequest request);
    }
}
