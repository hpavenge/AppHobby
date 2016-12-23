using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinSurprise.Objects;
using XamarinSurprise.Service;

namespace XamarinSurprise.Command
{
    class AuthorisationDenyCommand : ICommand
    {
        AuthorisationRequest authorisationRequest;
        private RestService restClient;

        public AuthorisationDenyCommand(AuthorisationRequest authorisationRequest)
        {
            this.authorisationRequest = authorisationRequest;
            restClient = new RestService();
        }
        public async void execute()
        {
            authorisationRequest.Deny();
            await restClient.UpdateAuthorisationTask(authorisationRequest);
        }
    }
}