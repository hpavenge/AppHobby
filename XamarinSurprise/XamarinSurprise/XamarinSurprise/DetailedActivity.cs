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
using XamarinSurprise.Business;
using XamarinSurprise.Objects;
using XamarinSurprise.Command;
using XamarinSurprise.Service;
using Android.Gms.Common;
using Firebase.Messaging;
using Firebase.Iid;


namespace XamarinSurprise
{
    [Activity(Label = "DetailedActivity", MainLauncher = true)]
    public class DetailedActivity : Activity
    {
        #region Fields
        private Button skipButton;
        private Button denyButton;
        private Button watchButton;
        private Button allowButton;
        private TextView infoTextView;
        private RestService restClient;
        private CommandController commandController;
        #endregion

        #region Constructor
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.layout2);
            restClient = new RestService();
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
            //Test Authorisation
            AuthorisationRequest authorisationRequest = await restClient.GetAuthorisationTask(9320);
            fillTextView(infoTextView, authorisationRequest);
            // Avaible Commands
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
        #endregion

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