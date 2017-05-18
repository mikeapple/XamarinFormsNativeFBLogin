using System;
using Xamarin.Forms;

namespace NativeFBLogin
{
    public partial class App : Application
    {
		public static Action<string> PostSuccessFacebookAction { get; set; }

		public App()
        {
            InitializeComponent();

            MainPage = new NativeFBLoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
