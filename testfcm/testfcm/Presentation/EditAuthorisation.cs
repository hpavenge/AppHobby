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
        private Button _skipButton;
        private Button _denyButton;
        private Button _watchButton;
        private Button _allowButton;
        //private TextView _infoTextView;
        private RestService _restClient;
        private CommandController _commandController;
        private ProgressDialog _progress;
        const string Tag = "EditAuthorisation";
        #endregion

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.EditAuthorisation);
            // Create your application here
            // Get Screen info
            _skipButton = FindViewById<Button>(Resource.Id.BtnSkip);
            _denyButton = FindViewById<Button>(Resource.Id.BtnDeny);
            _watchButton = FindViewById<Button>(Resource.Id.BtnWatch);
            _allowButton = FindViewById<Button>(Resource.Id.BtnAllow);
            //_infoTextView = FindViewById<TextView>(Resource.Id.TxtvInfo);
            _progress = new ProgressDialog(this);
            // link Click Events
            _skipButton.Click += SkipClick;
            _denyButton.Click += DenyClick;
            _watchButton.Click += WatchClick;
            _allowButton.Click += AllowClick;
            // Create controller
            _commandController = new CommandController();
            _restClient = new RestService();
            //Autorisation id + object
            if (Intent.Extras != null)
            {
                foreach (var key in Intent.Extras.KeySet())
                {
                    var value = Intent.Extras.GetString(key);
                    Log.Debug(Tag, "Key: {0} Value: {1}", key, value);
                    if (key == "AutorisationID")
                    {
                        var autorisationId = Convert.ToInt32(value);
                        ShowProgDialog();
                        AuthorisationRequest authorisationRequest = await _restClient.GetAuthorisationTask(autorisationId);
                        //FillTextView(_infoTextView, authorisationRequest);
                        FillTable(authorisationRequest);
                        _progress.Dismiss();
                        AuthorisationAllowCommand authoristionAllowCommand = new AuthorisationAllowCommand(authorisationRequest);
                        AuthorisationDenyCommand authorisationDenyCommand = new AuthorisationDenyCommand(authorisationRequest);
                        AuthorisationWatchCommand authorisationWatchCommand = new AuthorisationWatchCommand(authorisationRequest);
                        AuthorisationSkipCommand authorisationSkipCommand = new AuthorisationSkipCommand(authorisationRequest);
                        // Fill Controller with Commands
                        _commandController.SetCommand(0, authoristionAllowCommand);
                        _commandController.SetCommand(1, authorisationDenyCommand);
                        _commandController.SetCommand(2, authorisationWatchCommand);
                        _commandController.SetCommand(3, authorisationSkipCommand);
                    }
                }
            }
        }

        #region Methods

        private void SkipClick(object sender, EventArgs ea)
        {
            _commandController.LaunchCommand(3);
            Console.WriteLine("skip clicked");
            Finish();
        }

        private void DenyClick(object sender, EventArgs ea)
        {
            _commandController.LaunchCommand(1);
            Console.WriteLine("deny clicked");
            Finish();
        }

        private void WatchClick(object sender, EventArgs ea)
        {
            _commandController.LaunchCommand(2);
            Console.WriteLine("on my way clicked");
            Finish();
        }

        private void AllowClick(object sender, EventArgs ea)
        {
            _commandController.LaunchCommand(0);
            Console.WriteLine("allow clicked");
            Finish();
        }

        private void FillTextView(TextView infoView, AuthorisationRequest authorisationRequest)
        {
            infoView.Text = authorisationRequest.toString();
        }

        private void FillTable(AuthorisationRequest authorisationRequest)
        {
            // get table content
            TextView tableKassa = (TextView)FindViewById(Resource.Id.tableKassa);
            TextView tableOperator = (TextView)FindViewById(Resource.Id.tableOperator);
            TextView tableDescription = (TextView)FindViewById(Resource.Id.tableDescription);
            TextView tableLocation = (TextView)FindViewById(Resource.Id.tableLocation);
            TextView tableAmount = (TextView)FindViewById(Resource.Id.tableAmount);
            TextView tableShop = (TextView)FindViewById(Resource.Id.tableShop);
            TextView tableDate = (TextView)FindViewById(Resource.Id.tableDate);
            TextView tableTime = (TextView)FindViewById(Resource.Id.tableTime);
            // set table info
            tableKassa.Text = authorisationRequest.GetKassaId();
            tableOperator.Text = authorisationRequest.GetKassaOperatorName();
            tableDescription.Text = authorisationRequest.GetDescription();
            tableLocation.Text = authorisationRequest.GetLocation();
            tableAmount.Text = "€70,00";
            tableShop.Text = authorisationRequest.GetShopName();
            tableDate.Text = authorisationRequest.GetDate();
            tableTime.Text = authorisationRequest.GetTime();
        }

        void ShowProgDialog()
        {
            _progress.Indeterminate = true;
            _progress.SetProgressStyle(ProgressDialogStyle.Spinner);
            _progress.SetMessage("Contacting server. Please wait...");
            _progress.SetCancelable(false);
            _progress.Show();
        }
        #endregion
    }
}