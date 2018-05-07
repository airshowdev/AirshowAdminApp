using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AirshowAddmin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class pgCreate : ContentPage
	{
		public pgCreate ()
		{
			InitializeComponent ();
		}

        protected override bool OnBackButtonPressed()
        {
            try
            {
                App.Current.MainPage = new pgNavigation();
                return true;
            }
            catch (Exception E)
            {
                Console.WriteLine(E.ToString());
                return false;
            }

        }
    }
}