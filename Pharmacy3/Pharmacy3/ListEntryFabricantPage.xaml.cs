using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using Pharmacy3.Models;
namespace Pharmacy3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListEntryFabricantPage : ContentPage
    {
        public ListEntryFabricantPage()
        {
            InitializeComponent();
        }
        
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetFabricantAsync();

        }

        async void OnFabricantAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FabricantiPage
            {
                BindingContext = new Fabricant()
            });
        }
        async void OnList1ViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new FabricantiPage
                {
                    BindingContext = e.SelectedItem as Fabricant
                });

            }
        }
        
    }
}