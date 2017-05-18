using Android.App;
using Android.Content;
using Android.OS;
using Java.Lang;
using Xamarin.Facebook.Login;
using Xamarin.Facebook;
using System;
using NativeFBLogin;

[assembly: MetaData("com.facebook.sdk.ApplicationId", Value = "@string/app_id")]

namespace NativeFBLogin.Droid
{
    [Activity(Label = "")]
    public class FacebookActivity : Activity
    {
        ICallbackManager callbackManager;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            if(AccessToken.CurrentAccessToken != null)
            {
                App.PostSuccessFacebookAction(AccessToken.CurrentAccessToken.Token);
                Finish();
                return;
            }

            callbackManager = CallbackManagerFactory.Create();
            LoginManager.Instance.RegisterCallback(callbackManager, new FacebookCallBack());

            LoginManager.Instance.LogInWithReadPermissions(this, new string[] { "public_profile" });
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            callbackManager.OnActivityResult(requestCode, (int)resultCode, data);
            Finish();
        }
    }
                                                   
	public class FacebookCallBack : Java.Lang.Object, IFacebookCallback, IDisposable
	{
		#region IFacebookCallback implementation
		public void OnCancel()
		{

		}
		public void OnError(FacebookException p0)
		{

		}
		public void OnSuccess(Java.Lang.Object p0)
		{
			LoginResult loginResult = (LoginResult)p0;
			App.PostSuccessFacebookAction(loginResult.AccessToken.Token);
		}
		#endregion
	}
    
}
