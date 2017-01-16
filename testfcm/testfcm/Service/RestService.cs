using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using testfcm.Business.Objects;

namespace testfcm.Service
{
    class RestService : IRestService
    {
        private HttpClient _client;

        public RestService()
        {
            _client = new HttpClient
            {
                MaxResponseContentBufferSize = 256000,
                BaseAddress = new Uri("http://192.168.247.197:60917/api/")
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Method to get authorisationrequest from the rest api for now returns the json String
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AuthorisationRequest> GetAuthorisationTask(int id)
        {
            string path = "AutorisationAPI/ViewAutorisation/" + id;
            AuthorisationRequest authorisationRequest = null;
            HttpResponseMessage response = await _client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var jsonAuthorisation = await response.Content.ReadAsStringAsync();
                authorisationRequest = JsonConvert.DeserializeObject<AuthorisationRequest>(jsonAuthorisation);
            }
            return authorisationRequest;
        }

        public async Task UpdateAuthorisationTask(AuthorisationRequest authorisationRequest)
        {
            var uri = new Uri(string.Format(_client.BaseAddress + "AutorisationAPI/UpdateAutorisation/" + authorisationRequest.GetId()));
            string json = JsonConvert.SerializeObject(authorisationRequest);
            Console.WriteLine(json);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("succesfully edited");
            }
        }
    }
}