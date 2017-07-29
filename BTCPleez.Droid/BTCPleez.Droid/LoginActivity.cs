using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;

namespace BTCPleez.Droid
{
    [Activity(Label = "BTCPleez", MainLauncher = true, Icon = "@drawable/icon")]
    public class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Window.RequestFeature(WindowFeatures.ActionBar);
            ActionBar.Hide();

            // Set our view from the layout resource
            SetContentView (Resource.Layout.Login);

            var btnLogin = FindViewById<Button>(Resource.Id.btnLogin);

            btnLogin.Click -= BtnLogin_Click;
            btnLogin.Click += BtnLogin_Click;
        }

        private void BtnLogin_Click(object sender, System.EventArgs e)
        {
            Toast.MakeText(this, "Test", ToastLength.Short);
        }
    }
}

