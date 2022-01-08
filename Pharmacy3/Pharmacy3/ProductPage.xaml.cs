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
    public partial class ProductPage : ContentPage
    {
        Medicament m;
        public ProductPage(Medicament mm)
        {
            InitializeComponent();
            m = mm;
        }
        /*
        async void OnSaveButton3Clicked(object sender, EventArgs e)
        {
            var product = (Categorie)BindingContext;
            await App.Database.SaveCategorieAsync(product);
            listView.ItemsSource = await App.Database.GetCategorieAsync();
        }
        async void OnDeleteButton3Clicked(object sender, EventArgs e)
        {
            var product = (Categorie)BindingContext;
            await App.Database.DeleteCategorieAsync(product);
            listView.ItemsSource = await App.Database.GetCategorieAsync();
        }*/
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetCategorieAsync();
        }
        async void OnListView3ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Categorie c;
            if (e.SelectedItem != null)
            {
                c = e.SelectedItem as Categorie;
                var ml = new CategorieList()
                {
                    MedicamentID = m.ID,
                    CategorieID = c.ID
                };
                await App.Database.SaveListProductAsync(ml);
                c.CategorieLists = new List<CategorieList> { ml };
                await Navigation.PopAsync();
            }
        }
    }
}