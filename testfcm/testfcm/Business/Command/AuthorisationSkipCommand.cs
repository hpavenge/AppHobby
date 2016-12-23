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
using testfcm.Business.Objects;
using testfcm.Service;

namespace testfcm.Business.Command
{
    class AuthorisationSkipCommand : ICommand
    {
        AuthorisationRequest authorisationRequest;
        private RestService restClient;

        public AuthorisationSkipCommand(AuthorisationRequest authorisationRequest)
        {
            this.authorisationRequest = authorisationRequest;
            restClient = new RestService();
        }

        public async void execute()
        {
            authorisationRequest.Skip();
            await restClient.UpdateAuthorisationTask(authorisationRequest);
        }
    }
}