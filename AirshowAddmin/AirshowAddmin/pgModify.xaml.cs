using System;
using System.Collections.Generic;
using System.Net;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AirshowAddmin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class pgModify : ContentPage
	{
        public pgModify()
        {
            InitializeComponent();
            database = InfoStore.database;
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
        Database database;
        TableView tvSelectAirshow;
        IList<View> children;
        TableRoot Airshows;

        IList<String> airshowNames;

        private void StackLayout_LayoutChanged(object sender, EventArgs e)
        {
            {
                try {
                    StackLayout slModify = sender as StackLayout;
                    children = slModify.Children;
                    foreach (View v in children)
                    {
                        if (children[0].GetType() == typeof(TableView) && tvSelectAirshow == null)
                        {
                            
                            airshowNames = database.AirshowNames;
                            tvSelectAirshow = children[0] as TableView;
                            tvSelectAirshow.Root.Clear();
                            Airshows = tvSelectAirshow.Root;
                            TableSection Airshow = new TableSection();

                            foreach (String name in airshowNames)
                            {
                                TextCell AirshowName = new TextCell();
                                AirshowName.Text = name;
                                AirshowName.TextColor = Color.Black;
                                Airshow.Add(AirshowName);
                                AirshowName.Tapped += AirshowClicked;
                            }
                            Airshows.Add(Airshow);
                            tvSelectAirshow.Root = Airshows;

                        }
                        if (children[1].GetType() == typeof(TableView))
                        {

                        }
                    }
                    Airshows.Clear();
                }
                catch (Exception E)
                {
                }
                
            }

        }

        private void AirshowClicked(object sender, EventArgs e)
        {
            try
            {
                InfoStore.Selected = (sender as TextCell).Text;
                LoadPage(new ModificationPage());
            }
            catch (Exception E)
            {
                E.ToString();
            }
            

        }

        private async void LoadPage(ContentPage page) 
        {
            
                NavigationPage navPage = new NavigationPage(page);
                page.Parent = null;
                await navPage.Navigation.PushAsync(page);
                App.Current.MainPage = page;
        }
    }
}