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
	public partial class pgNavigation : ContentPage
	{
		public pgNavigation ()
		{
			InitializeComponent ();
		}

        IList<View> children;

        private void StackLayout_LayoutChanged(object sender, EventArgs e)
        {
            StackLayout slNavigation = sender as StackLayout;
            children = slNavigation.Children;
        }

        private void btnModify_Clicked(object sender, EventArgs e)
        {
            LoadPage(new pgModify());
        }

        private void btnCreate_Clicked(object sender, EventArgs e)
        {
            LoadPage(new pgCreate());
        }

        private async void LoadPage(ContentPage page)
        {
            NavigationPage navPage = new NavigationPage(page);
            page.Parent = null;
            await  navPage.Navigation.PushAsync(page);
            App.Current.MainPage = page;
        }
        
        
    }
}