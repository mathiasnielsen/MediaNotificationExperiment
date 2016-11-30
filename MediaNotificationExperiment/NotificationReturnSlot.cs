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

namespace MediaNotificationExperiment
{
    [Activity(LaunchMode = Android.Content.PM.LaunchMode.SingleTask, TaskAffinity = "", ExcludeFromRecents = true)]
    public class NotificationReturnSlot : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var action = (String)Intent.Extras.Get("DO");
            if (action.Equals("frederik"))
            {
                System.Diagnostics.Debug.WriteLine("You pressed frederik");
                //Your code
            }
            else if (action.Equals("stopNotification"))
            {
                System.Diagnostics.Debug.WriteLine("You pressed stop");
                ////Log.i("NotificationReturnSlot", "stopNotification");
            }

            Finish();
        }
    }
}
