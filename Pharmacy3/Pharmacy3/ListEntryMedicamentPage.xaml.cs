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
    public partial class ListEntryMedicamentPage : ContentPage
    {
        public ListEntryMedicamentPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetMedicamentAsync();

        }

        async void OnMedicamentAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MedicamentePage
            {
                BindingContext = new Medicament()
            });
        }
        async void OnList2ViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new MedicamentePage
                {
                    BindingContext = e.SelectedItem as Medicament
                });

            }
        }
    }
}