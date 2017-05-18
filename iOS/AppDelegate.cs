using Foundation;
using UIKit;
using Facebook.CoreKit;

namespace NativeFBLogin.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
			Settings.AppID = "1840011542984981";
			Settings.DisplayName = "Xama­r­i­n­F­o­r­m­s­N­a­t­i­v­e­L­ogin";

            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());

            ApplicationDelegate.SharedInstance.FinishedLaunching(app, options);
            return base.FinishedLaunching(app, options);
        }

		public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
            return ApplicationDelegate.SharedInstance.OpenUrl(application,
															  url,
															  sourceApplication,
															  annotation);
		}

		public override void OnActivated(UIApplication uiApplication)
		{
			base.OnActivated(uiApplication);
			AppEvents.ActivateApp();
		}
    }
}
