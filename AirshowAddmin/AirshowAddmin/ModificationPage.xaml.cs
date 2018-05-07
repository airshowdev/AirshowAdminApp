using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AirshowAddmin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModificationPage : ContentPage
    {
        public ModificationPage()
        {
            InitializeComponent();
            database = InfoStore.database;
        }

        Database database;

        IList<Tuple<string,object>> Properties;

        static readonly IList<string> buttons = new ReadOnlyCollection<string>(new List<string> { "Performers", "Directions", "Statics", "Foods" }) ;

        private bool LoadBoxes(ScrollView sv)
        {
            try
            {
                Properties = Database.getAirshowInfo(InfoStore.Selected);
                IReadOnlyList<Element> children = sv.Children;
                TableView tvProperties = children[0] as TableView;
                TableSection tsPropertires = new TableSection();

                sv.HeightRequest = App.Current.MainPage.Height;
                tvProperties.Margin = 5;

                foreach (Tuple<string, object> prop in Properties)
                {
                    ViewCell vcProperty = new ViewCell();
                    StackLayout slProperty = new StackLayout();
                    vcProperty.Height = slProperty.Height;
                    slProperty.Orientation = StackOrientation.Horizontal;


                    if (buttons.Contains(prop.Item1))
                    {
                        Button btnProperty = new Button();
                        btnProperty.Text = prop.Item1 as string;
                        btnProperty.TextColor = Color.Black;
                        slProperty.Children.Add(btnProperty);
                    }
                    else
                    {
                        Label lblProperty = new Label();
                        Entry txtProperty = new Entry();

                        lblProperty.Text = prop.Item1 as string + ":";
                        lblProperty.TextColor = Color.Black;
                        lblProperty.VerticalTextAlignment = TextAlignment.Center;
                        lblProperty.HorizontalTextAlignment = TextAlignment.Start;
                        lblProperty.FontSize = 16;
                        lblProperty.Margin = 0;
                        lblProperty.WidthRequest = lblProperty.Text.Count() * lblProperty.FontSize * 0.66;


                        txtProperty.Text = prop.Item2 as string;
                        txtProperty.TextColor = Color.Black;
                        txtProperty.MinimumWidthRequest = 0;
                        txtProperty.HeightRequest = txtProperty.Text.Count() * txtProperty.FontSize * 1.2;
                        txtProperty.WidthRequest = (txtProperty.WidthRequest > App.Current.MainPage.Width - lblProperty.WidthRequest) ?
                            App.Current.MainPage.Width - lblProperty.WidthRequest : txtProperty.Text.Count() * lblProperty.FontSize * 0.72;

                        slProperty.Children.Add(lblProperty);
                        slProperty.Children.Add(txtProperty);
                    }
                    vcProperty.View = slProperty as View;
                    tsPropertires.Add(vcProperty);
                }

                Button btnSave = new Button()
                {
                    Text = "Save",
                    TextColor = Color.Black,
                    WidthRequest = App.Current.MainPage.Width,
                };

                ViewCell vcSave = new ViewCell() {
                    View = btnSave
                };
                tsPropertires.Add(vcSave);
                btnSave.Clicked += btnSave_Clicked;
                TableRoot root = tvProperties.Root;
                root.Add(tsPropertires);
                tvProperties.Root = root;
                return true;
            }
            catch (Exception E)
            {
                return false;
            }

        }

        bool bolLoaded = false;

        private void ScrollView_LayoutChanged(object sender, EventArgs e)
        {
            if (!bolLoaded)
                bolLoaded = LoadBoxes(sender as ScrollView);
        }

        private void btnSave_Clicked(object send, EventArgs e)
        {
            try
            {
                OnBackButtonPressed();
            }
            catch (Exception E)
            {
                E.ToString();
            }
        }

        protected override bool OnBackButtonPressed()
        {
            try
            {
                App.Current.MainPage = new pgModify();
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