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
    [Android.Runtime.Register("android/annotation/SuppressLint", DoNotGenerateAcw = true)]
    [System.Obsolete("Use ISuppressLint interface instead")]
    public class MediaNotification : Notification
    {
        private Context context;
        private NotificationManager notificationManager;

        public MediaNotification(Context context)
        {
            this.context = context;
            notificationManager = (NotificationManager)context.GetSystemService(Context.NotificationService);

            var tickerText = "ShortCuts";
            var now = DateTime.Now;

            var builder = new Builder(context);
            var notification = builder.Notification;

            notification.When = now.Ticks;
            notification.TickerText = new Java.Lang.String(tickerText);
            notification.Icon = Resource.Drawable.Icon;
            
            var contentView = new RemoteViews(context.PackageName, Resource.Layout.MessageView);

            SetListeners(contentView);

            notification.ContentView = contentView;
            notification.Flags |= NotificationFlags.OngoingEvent;
            var contentTitle = new Java.Lang.String("From Shortcuts");
            notificationManager.Notify(548853, notification);
        }

        public void SetListeners(RemoteViews view)
        {
            //radio listener
            ////Intent radio = new Intent(context, typeof(HelperActivity));
            ////radio.PutExtra("DO", "radio");
            ////PendingIntent pRadio = PendingIntent.GetActivity(context, 0, radio, 0);
            ////view.SetOnClickPendingIntent(Resource.Id.radio, pRadio);

            //////volume listener
            ////Intent volume = new Intent(context, typeof(HelperActivity));
            ////volume.PutExtra("DO", "volume");
            ////PendingIntent pVolume = PendingIntent.GetActivity(context, 1, volume, 0);
            ////view.SetOnClickPendingIntent(Resource.Id.volume, pVolume);

            //////reboot listener
            ////Intent reboot = new Intent(context, typeof(HelperActivity));
            ////reboot.PutExtra("DO", "reboot");
            ////PendingIntent pReboot = PendingIntent.GetActivity(context, 5, reboot, 0);
            ////view.SetOnClickPendingIntent(Resource.Id.reboot, pReboot);

            //////top listener
            ////Intent top = new Intent(context, typeof(HelperActivity));
            ////top.PutExtra("DO", "top");
            ////PendingIntent pTop = PendingIntent.GetActivity(context, 3, top, 0);
            ////view.SetOnClickPendingIntent(Resource.Id.top, pTop);

            //app listener
            Intent app = new Intent(context, typeof(HelperActivity));
            app.PutExtra("DO", "app");
            PendingIntent pApp = PendingIntent.GetActivity(context, 4, app, 0);
            view.SetOnClickPendingIntent(Resource.Id.btn1, pApp);
        }
    }

    [Activity]
    public class HelperActivity : Activity
    {
        private HelperActivity context;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            context = this;

            var action = (string)Intent.Extras.Get("DO");
            if (action.Equals("radio"))
            {
                //Your code
            }
            else if (action.Equals("volume"))
            {
                //Your code
            }
            else if (action.Equals("reboot"))
            {
                //Your code
            }
            else if (action.Equals("top"))
            {
                //Your code
            }
            else if (action.Equals("app"))
            {
                //Your code
            }

            if (!action.Equals("reboot"))
            {
                Finish();
            }
        }
    }
}