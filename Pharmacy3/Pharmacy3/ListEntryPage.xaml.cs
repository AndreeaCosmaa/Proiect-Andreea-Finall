using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Pharmacy3.Models;
namespace Pharmacy3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListEntryPage : ContentPage
    {
        public ListEntryPage()
        {
            InitializeComponent();
        }
        
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetCategorieAsync();
                      
        }
        async void OnCategorieAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CategoriiPage
            {
                BindingContext = new Categorie()
            });
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new CategoriiPage
                {
                    BindingContext = e.SelectedItem as Categorie
                });
             
            }
        }
        
    }
}