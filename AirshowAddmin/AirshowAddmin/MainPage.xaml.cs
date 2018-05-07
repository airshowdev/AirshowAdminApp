using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net;
using System.Net.Http;

namespace AirshowAddmin
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

		}

        StackLayout slLogin = null;

        private void slLogin_ChildAdded(object sender, EventArgs e)
        {
            slLogin = sender as StackLayout;
            IList<View> slChildren = slLogin.Children;
            foreach (View v in slChildren)
            {
                if (v.GetType() != typeof(Button))
                {
                    v.WidthRequest = slLogin.Width;
                }
            }
        }
        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            NavigationPage navPage = new NavigationPage(this);
            IList<View> children = slLogin.Children;

            Entry txtUsername = children[0] as Entry;
            Entry txtPassword = children[1] as Entry;

            Button btnLogin = children[2] as Button;
            if (txtUsername.Text != " " && txtPassword.Text != " ")
            {
                StoreDatabase();
                App.Current.MainPage = new pgNavigation();

                
            }

        }
        HttpClient client = new HttpClient();
        private async void StoreDatabase()
        {
            var json = await client.GetStringAsync("https://airshowapp-d193b.firebaseio.com/.json");
            Console.WriteLine(json);
            InfoStore.database = Database.FromJson(json);
        }
    }
}
