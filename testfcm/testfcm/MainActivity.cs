using Android.App;
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

    [Activity(Label = "testfcm", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        TextView msgText;
        const string TAG = "MainActivity";
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            msgText = FindViewById<TextView> (Resource.Id.msgText);
            var subscribeButton = FindViewById<Button>(Resource.Id.subscribeButton);
            IsPlayServicesAvailable ();
            var logTokenButton = FindViewById<Button>(Resource.Id.logTokenButton);
            logTokenButton.Click += delegate {
                Log.Debug(TAG, "InstanceID token: " + FirebaseInstanceId.Instance.Token);
            };
            subscribeButton.Click += delegate {
                Instance.SubscribeToTopic("news");
                Log.Debug(TAG, "Subscribed to remote notifications");
            };
        }

        public bool IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                    msgText.Text = GoogleApiAvailability.Instance.GetErrorString(resultCode);
                else
                {
                    msgText.Text = "This device is not supported";
                    Finish();
                }
                return false;
            }
            else
            {
                msgText.Text = "Google Play Services is available.";
                return true;
            }
        }


    }
}

