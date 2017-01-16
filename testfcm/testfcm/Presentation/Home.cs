using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Messaging;
using testfcm.Presentation;

namespace testfcm
{
    [Activity(Label = "Home")]
    public class Home : Activity
    {
        private TextView _statusText;
        private Button _pauzeButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Home);
            var historyButton = FindViewById<Button>(Resource.Id.btHistory);
            _pauzeButton = FindViewById<Button>(Resource.Id.btPause);
            var logoutButton = FindViewById<Button>(Resource.Id.btLogout);
            _statusText = FindViewById<TextView>(Resource.Id.tvStatus);
            historyButton.Click += HistoryClick;
            _pauzeButton.Click += PauzeClick;
            logoutButton.Click += LogoutClick;
        }

        void HistoryClick(object sender, EventArgs ea)
        {
            Console.WriteLine("history clicked");
            var activity = new Intent(this, typeof(History));
            StartActivity(activity);
        }

        void PauzeClick(object sender, EventArgs ea)
        {
            Console.WriteLine("pauze clicked");
            Pauze(_statusText.Text);
        }

        void LogoutClick(object sender, EventArgs ea)
        {
            Console.WriteLine("logout clicked");
            Logout();
        }

        void Pauze(String status)
        {
            if (status == "Aan")
            {
                FirebaseMessaging.Instance.UnsubscribeFromTopic("news");
                _statusText.Text = "Pauze";
                _statusText.SetTextColor(Color.Orange);
                _pauzeButton.Text = "Start";
                _pauzeButton.SetCompoundDrawablesWithIntrinsicBounds(GetDrawable(Resource.Drawable.ic_allow),null,null,null);
                Toast("Notifications paused");
            }
            else
            {
                FirebaseMessaging.Instance.SubscribeToTopic("news");
                _statusText.Text = "Aan";
                _statusText.SetTextColor(Color.White);
                _pauzeButton.Text = "Pauze";
                _pauzeButton.SetCompoundDrawablesWithIntrinsicBounds(GetDrawable(Resource.Drawable.ic_pause), null, null, null);
                Toast("Receiving notifications");
            }

        }

        void Logout()
        {
            FirebaseMessaging.Instance.UnsubscribeFromTopic("news");
            var activity = new Intent(this, typeof(MainActivity));
            StartActivity(activity);
        }

        void Toast(string message)
        {
            Android.Widget.Toast.MakeText(this, message, ToastLength.Short).Show(); ;
        }
    }
}