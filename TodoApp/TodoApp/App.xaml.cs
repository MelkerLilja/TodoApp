using System;
using TodoApp.Data;
using TodoApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace TodoApp
{
    public partial class App : Application
    {
        static ListDatabase database;

        public App()
        {
            InitializeComponent();

            var nav = new NavigationPage(new ListPage());
            nav.BarBackgroundColor = Color.LightBlue;
            nav.BarTextColor = Color.Black;

            MainPage = nav;
        }

        public static ListDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ListDatabase();
                }
                return database;
            }
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
    
}