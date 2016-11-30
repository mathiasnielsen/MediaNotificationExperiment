using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Views;

namespace MediaNotificationExperiment
{
    [Activity(Label = "MediaNotificationExperiment", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var play = FindViewById<Button>(Resource.Id.playButton);
            var pause = FindViewById<Button>(Resource.Id.pauseButton);
            var stop = FindViewById<Button>(Resource.Id.stopButton);

            ////play.Click += (sender, args) => ShowNotification();
            play.Click += (sender, args) => ShowAppCompatNotif();

            ////play.Click += (sender, args) => SendAudioCommand(StreamingBackgroundService.ActionPlay);
            ////pause.Click += (sender, args) => SendAudioCommand(StreamingBackgroundService.ActionPause);
            ////stop.Click += (sender, args) => SendAudioCommand(StreamingBackgroundService.ActionStop);
        }

        public void ShowAppCompatNotif()
        {
            new NotificationPanel(this);
        }

        public void ShowNotification()
        {
            new MediaNotification(this);
            Finish();
        }

        private void SendAudioCommand(string action)
        {
            var intent = new Intent(action);
            StartService(intent);
        }
    }
}

