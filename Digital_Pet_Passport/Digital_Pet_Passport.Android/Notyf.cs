using Android.Widget;
using Xamarin.Forms;

[assembly: Dependency(typeof(Digital_Pet_Passport.Droid.Notyf))]
namespace Digital_Pet_Passport.Droid
{

    public class Notyf : Intefaces.INotyf
    {
       
        public void ToastMsg( string msg)
        {
            Toast.MakeText(Android.App.Application.Context, msg, ToastLength.Short);
        }
    }
}