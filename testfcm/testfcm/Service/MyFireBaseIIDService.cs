﻿using Android.App;
using Android.Util;
using Firebase;
using Firebase.Iid;

namespace testfcm
{
        [Service]
        [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
        public class MyFirebaseIIDService : FirebaseInstanceIdService
        {
            const string TAG = "MyFirebaseIIDService";
            public override void OnTokenRefresh()
            {
                var refreshedToken = FirebaseInstanceId.Instance.Token;
                Log.Debug(TAG, "Refreshed token: " + refreshedToken);
                SendRegistrationToServer(refreshedToken);
            }
            void SendRegistrationToServer(string token)
            {
                // Add custom implementation, as needed.
            }
        }
}