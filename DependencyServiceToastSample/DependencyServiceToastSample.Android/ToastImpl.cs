using Android.App;
using Android.Widget;
using DependencyServiceToastSample.Droid;
[assembly: Xamarin.Forms.Dependency(typeof(ToastImpl))]
namespace DependencyServiceToastSample.Droid
{
    public class ToastImpl : IToast
    {
        public ToastImpl()
        {
        }
        public void Show(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}

