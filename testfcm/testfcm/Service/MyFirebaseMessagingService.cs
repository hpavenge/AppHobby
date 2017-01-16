using System.Collections;
using Android.App;
using Android.Content;
using Android.Util;
using Firebase.Messaging;

namespace testfcm
{
    /// <summary>
    /// Only for ForeGround messages
    /// </summary>
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        const string Tag = "MyFirebaseMsgService";
        public override void OnMessageReceived(RemoteMessage message)
        {
            Log.Debug(Tag, "From: " + message.From);
            Log.Debug(Tag, "Notification Message Body: " + message.GetNotification().Body);
            if (message.Data != null)
            {
                if (message.Data.ContainsKey("AutorisationID"))
                {
                    Log.Debug("info", "data is filled");
                    string value = message.Data["AutorisationID"];
                    Log.Debug("Id =", value);
                    var activity = new Intent(this,typeof(EditAuthorisation));
                    activity.PutExtra("AutorisationID", value);
                    activity.SetFlags(ActivityFlags.NewTask);
                    StartActivity(activity);
                }
            }

        }
    }
}