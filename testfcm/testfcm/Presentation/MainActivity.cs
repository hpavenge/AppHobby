using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Gms.Common;
using Android.Util;
using Firebase;
using Firebase.Iid;
using Java.IO;
using static Firebase.Messaging.FirebaseMessaging;


namespace testfcm
{

    [Activity(Label = "Axi Autorisatie", MainLauncher = true, Icon = "@drawable/axi_launcher")]
    public class MainActivity : Activity
    {
        TextView _msgText;
        const string Tag = "MainActivity";
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            _msgText = FindViewById<TextView> (Resource.Id.msgText);
            var subscribeButton = FindViewById<Button>(Resource.Id.subscribeButton);
            IsPlayServicesAvailable ();
            var logTokenButton = FindViewById<Button>(Resource.Id.logTokenButton);
            logTokenButton.Click += delegate {
                Log.Debug(Tag, "InstanceID token: " + FirebaseInstanceId.Instance.Token);
            };
            subscribeButton.Click += delegate {
                Instance.SubscribeToTopic("news");
                Toast.MakeText(this, "Receiving notifications", ToastLength.Short).Show();
                Log.Debug(Tag, "Subscribed to remote notifications");
                var activity = new Intent(this, typeof(Home));
                StartActivity(activity);
            };
        }

        public bool IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                    _msgText.Text = GoogleApiAvailability.Instance.GetErrorString(resultCode);
                else
                {
                    _msgText.Text = "This device is not supported";
                    Finish();
                }
                return false;
            }
            else
            {
                _msgText.Text = "Google Play Services is available.";
                return true;
            }
        }


    }
}

