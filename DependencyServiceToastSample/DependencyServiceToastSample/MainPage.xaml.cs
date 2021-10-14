using Xamarin.Forms;

namespace DependencyServiceToastSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void btnShowShort_Clicked(System.Object sender, System.EventArgs e)
        {
            DependencyService.Get<IToast>().Show("Hello, Xamarin!");
        }
    }
}
