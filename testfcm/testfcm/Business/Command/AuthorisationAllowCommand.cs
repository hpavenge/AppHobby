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
    class AuthorisationAllowCommand : ICommand
    {
        AuthorisationRequest _authorisationRequest;
        private RestService _restClient;

        public AuthorisationAllowCommand(AuthorisationRequest authorisationRequest)
        {
            this._authorisationRequest = authorisationRequest;
            _restClient = new RestService();
        }
        public async void Execute()
        {
            _authorisationRequest.Authorize("allow", "Nick van der Raaf");
            await _restClient.UpdateAuthorisationTask(_authorisationRequest);

        }
    }
}