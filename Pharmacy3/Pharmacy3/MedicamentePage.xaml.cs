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
    public partial class MedicamentePage : ContentPage
    {
        public MedicamentePage()
        {
            InitializeComponent();
        }
        async void OnSaveButton2Clicked(object sender, EventArgs e)
        {
            var slist = (Medicament)BindingContext;
            await App.Database.SaveMedicamentAsync(slist);
            //navigheaza la pagina precedenta
            await Navigation.PopAsync();
        }
        async void OnDeleteButton2Clicked(object sender, EventArgs e)
        {
            var slist = (Medicament)BindingContext;
            await App.Database.DeleteMedicamentAsync(slist);
            //navigheaza la pagina precedenta
            await Navigation.PopAsync();
        }
        async void OnSelectCategory(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new ProductPage((Medicament)this.BindingContext)
            {
                BindingContext = new Categorie()
            });
        }/*
        async void OnSelectFabricant(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ProductFabricantPage((Medicament)this.BindingContext)
            {
                BindingContext = new Fabricant()
            });
        }*/
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var shopl = (Medicament)BindingContext;
            listView1.ItemsSource = await App.Database.GetListProductsAsync(shopl.ID);
        }
    }
}