using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pharmacy3.Data;
using System.IO;
namespace Pharmacy3
{
    public partial class App : Application
    {
        static CategorieDatabase database;
        public static CategorieDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new CategorieDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                    LocalApplicationData), "ShoppingList.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new EntryPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
