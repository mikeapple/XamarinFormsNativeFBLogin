using System;
using Android.App;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Object = Java.Lang.Object;
using View = Android.Views.View;
using NativeFBLogin;
using NativeFBLogin.Droid;
using Xamarin.Facebook;

[assembly: ExportRenderer(typeof(FacebookLoginButton), typeof(FacebookLoginButtonRendererAndroid))]

namespace NativeFBLogin.Droid
{
	public class FacebookLoginButtonRendererAndroid : ButtonRenderer
	{
		private static Activity _activity;

		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);

			_activity = this.Context as Activity;

            //DEBUG
            //Xamarin.Facebook.Login.LoginManager.Instance.LogOut();

			if (this.Control != null)
			{
				Android.Widget.Button button = this.Control;
				button.SetOnClickListener(ButtonClickListener.Instance.Value);
			}

			if (AccessToken.CurrentAccessToken != null)
			{
                App.PostSuccessFacebookAction(AccessToken.CurrentAccessToken.Token);
			}
		}

		private class ButtonClickListener : Object, IOnClickListener
		{
			public static readonly Lazy<ButtonClickListener> Instance = new Lazy<ButtonClickListener>(() => new ButtonClickListener());

			public void OnClick(View v)
			{
				var myIntent = new Intent(_activity, typeof(FacebookActivity));
				_activity.StartActivityForResult(myIntent, 0);
			}
		}
	}
}
