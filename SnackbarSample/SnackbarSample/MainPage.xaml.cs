using Xamarin.Forms;
using Xamarin.CommunityToolkit.Extensions;
using System.Threading.Tasks;
using System;
using Xamarin.CommunityToolkit.UI.Views.Options;

namespace SnackbarSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void button1_Clicked(System.Object sender, System.EventArgs e)
        {
            await this.DisplayToastAsync("Hello, Toast!", 2000);
        }
        async void button2_Clicked(System.Object sender, System.EventArgs e)
        {
            var options = new ToastOptions
            {
                MessageOptions = new MessageOptions
                {
                    Foreground = Color.White,
                    Message = "Do you like Xamarin.Forms???"
                },
                BackgroundColor = Color.FromHex("#cfd8dc"),
                Duration = TimeSpan.FromSeconds(2),
                IsRtl = false,
                CornerRadius = new Thickness(40)
            };
            await this.DisplayToastAsync(options);
        }

        async void button3_Clicked(System.Object sender, System.EventArgs e)
        {
            await this.DisplaySnackBarAsync("Hello, SnackBar!", "Action1", SnackBarAction);
        }

        async void button4_Clicked(System.Object sender, System.EventArgs e)
        {
            var actions = new SnackBarActionOptions
            {
                Action = () => DisplayAlert("Title", "Message", "OK"),
                Text = "Yes"
            };
            var options = new SnackBarOptions
            {
                MessageOptions = new MessageOptions
                {
                    Foreground = Color.White,
                    Message = "Do you like Xamarin.Forms???"
                },
                BackgroundColor = Color.FromHex("#f06292"),
                Duration = TimeSpan.FromSeconds(2),
                Actions = new[] { actions }
            };
            await this.DisplaySnackBarAsync(options);
            // イベント発行元のオブジェクト上にSnackBarを表示する方法
            // await (sender as VisualElement).DisplaySnackBarAsync(options); 
        }

        private Task SnackBarAction()
        {
            return DisplayAlert("Title", "Message", "OK");
        }
    }
}
