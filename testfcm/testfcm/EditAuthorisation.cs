using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using testfcm.Business;
using testfcm.Business.Command;
using testfcm.Business.Objects;
using testfcm.Service;

namespace testfcm
{
    [Activity(Label = "EditAuthorisation"), IntentFilter(new[] { "ACTIVITY_AUTI" }, Categories = new[] { "android.intent.category.DEFAULT" })]
    public class EditAuthorisation : Activity
    {
        #region Fields
        private Button skipButton;
        private Button denyButton;
        private Button watchButton;
        private Button allowButton;
        private TextView infoTextView;
        private RestService restClient;
        private CommandController commandController;
        const string TAG = "EditAuthorisation";
        #endregion

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.EditAuthorisation);
            // Create your application here
            // Get Screen info
            skipButton = FindViewById<Button>(Resource.Id.BtnSkip);
            denyButton = FindViewById<Button>(Resource.Id.BtnDeny);
            watchButton = FindViewById<Button>(Resource.Id.BtnWatch);
            allowButton = FindViewById<Button>(Resource.Id.BtnAllow);
            infoTextView = FindViewById<TextView>(Resource.Id.TxtvInfo);
            // link Click Events
            skipButton.Click += skipClick;
            denyButton.Click += denyClick;
            watchButton.Click += watchClick;
            allowButton.Click += allowClick;
            // Create controller
            commandController = new CommandController();
            restClient = new RestService();
            //Test Authorisation Firebase
            if (Intent.Extras != null)
            {
                foreach (var key in Intent.Extras.KeySet())
                {
                    var value = Intent.Extras.GetString(key);
                    Log.Debug(TAG, "Key: {0} Value: {1}", key, value);
                    if (key == "AutorisationID")
                    {
                        var autorisationId = Convert.ToInt32(value);
                        AuthorisationRequest authorisationRequest = await restClient.GetAuthorisationTask(autorisationId);
                        fillTextView(infoTextView, authorisationRequest);
                        AuthorisationAllowCommand authoristionAllowCommand = new AuthorisationAllowCommand(authorisationRequest);
                        AuthorisationDenyCommand authorisationDenyCommand = new AuthorisationDenyCommand(authorisationRequest);
                        AuthorisationWatchCommand authorisationWatchCommand = new AuthorisationWatchCommand(authorisationRequest);
                        AuthorisationSkipCommand authorisationSkipCommand = new AuthorisationSkipCommand(authorisationRequest);
                        // Fill Controller with Commands
                        commandController.setCommand(0, authoristionAllowCommand);
                        commandController.setCommand(1, authorisationDenyCommand);
                        commandController.setCommand(2, authorisationWatchCommand);
                        commandController.setCommand(3, authorisationSkipCommand);
                    }
                }
            }
        }

        #region Methods
        void skipClick(object sender, EventArgs ea)
        {
            commandController.launchCommand(3);
            Console.WriteLine("skip clicked");
        }
        void denyClick(object sender, EventArgs ea)
        {
            commandController.launchCommand(1);
            Console.WriteLine("deny clicked");
        }
        void watchClick(object sender, EventArgs ea)
        {
            commandController.launchCommand(2);
            Console.WriteLine("on my way clicked");
        }
        void allowClick(object sender, EventArgs ea)
        {
            commandController.launchCommand(0);
            Console.WriteLine("allow clicked");
        }

        void fillTextView(TextView infoView, AuthorisationRequest authorisationRequest)
        {
            infoView.Text = authorisationRequest.toString();
        }
        #endregion
    }
}