using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using static Android.Widget.RemoteViews;

namespace MediaNotificationExperiment
{
    public class NotificationPanel : NotificationCompat
    {
        private Context parent;
        private Builder builder;
        private NotificationManager manager;

        public NotificationPanel(Context parent)
        {
            this.parent = parent;
            builder = new Builder(parent);

            builder.SetContentTitle("Parking meter");
            builder.SetSmallIcon(Resource.Drawable.Icon);
            builder.SetOngoing(true);

            var remoteView = new RemoteViews(parent.PackageName, Resource.Layout.MessageView);

            SetListeners(remoteView);
            builder.SetContent(remoteView);

            manager = (NotificationManager)parent.GetSystemService(Context.NotificationService);
            manager.Notify(2, builder.Build());
        }

        public void SetListeners(RemoteViews view)
        {
            //listener 1
            ////Intent volume = new Intent(parent, NotificationReturnSlot.class);
            ////volume.putExtra("DO", "volume");
            ////PendingIntent btn1 = PendingIntent.getActivity(parent, 0, volume, 0);
            ////    view.setOnClickPendingIntent(R.id.btn1, btn1);

            //listener 2
            Intent stop = new Intent(parent, typeof(NotificationReturnSlot));
            stop.PutExtra("DO", "stopNotification");
            PendingIntent btn1 = PendingIntent.GetActivity(parent, 0, stop, 0);
            view.SetOnClickPendingIntent(Resource.Id.btn1, btn1);

            Intent frederik = new Intent(parent, typeof(NotificationReturnSlot));
            stop.PutExtra("DO", "frederik");
            PendingIntent btn2 = PendingIntent.GetActivity(parent, 1, stop, 0);
            view.SetOnClickPendingIntent(Resource.Id.btn2, btn2);
        }

        public void NotificationCancel()
        {
            manager.Cancel(2);
        }
    }
}