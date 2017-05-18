using Xamarin.Forms;

namespace NativeFBLogin
{
    public partial class NativeFBLoginPage : ContentPage
    {
        public NativeFBLoginPage()
        {
            InitializeComponent();

			App.PostSuccessFacebookAction = token =>
			{
                resultLabel.Text = token;
			};
		}
    }
}
