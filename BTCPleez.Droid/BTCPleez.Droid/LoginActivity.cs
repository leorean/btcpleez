using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Content;
using System.Threading.Tasks;
using System.Text;
using System.Security.Cryptography;
using System;

namespace BTCPleez.Droid
{
    [Activity(Label = "BTCPleez", MainLauncher = true, 
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait,
        HardwareAccelerated = true)]
    public class LoginActivity : Activity
    {

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView (Resource.Layout.Login);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "Login";

            var btnLogin = FindViewById<Button>(Resource.Id.btnLogin);

            btnLogin.Click -= BtnLogin_Click;
            btnLogin.Click += BtnLogin_Click;

        }

        private async void BtnLogin_Click(object sender, System.EventArgs e)
        {
            var txtUser = FindViewById<TextView>(Resource.Id.txtUser);
            var txtPassword = FindViewById<TextView>(Resource.Id.txtPassword);

            Toast.MakeText(this, "logging in as " + txtUser.Text + "..", ToastLength.Short).Show();

            //faking log-in
            await Task.Delay(500);
            
            var intent = new Intent(this, typeof(DashboardActivity));

            intent.PutExtra("USER", txtUser.Text);
            intent.PutExtra("HASH", GetPassHash(txtPassword.Text));

            StartActivityForResult(intent, 0);
        }

        private string GetPassHash(string input)
        {
            // byte array representation of that string
            byte[] encodedPassword = new UTF8Encoding().GetBytes(input);

            // need MD5 to calculate the hash
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);

            // string representation (similar to UNIX format)
            return BitConverter.ToString(hash)
               // without dashes
               .Replace("-", string.Empty)
               // make lowercase
               .ToLower();
        }
    }
}

