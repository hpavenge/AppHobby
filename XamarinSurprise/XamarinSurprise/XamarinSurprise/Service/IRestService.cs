using System.Threading.Tasks;
using XamarinSurprise.Objects;

namespace XamarinSurprise.Service
{
    internal interface IRestService
    {
        /// <summary>
        /// Method to get authorisationrequest from the rest api for now returns the json String
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AuthorisationRequest> GetAuthorisationTask(int id);

        Task UpdateAuthorisationTask(AuthorisationRequest authorisationRequest);
    }
}