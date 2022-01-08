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
    public partial class FabricantiPage : ContentPage
    {
        public FabricantiPage()
        {
            InitializeComponent();
        }
        
        async void OnSaveButton1Clicked(object sender, EventArgs e)
        {
            var slist = (Fabricant)BindingContext;
            await App.Database.SaveFabricantAsync(slist);
            //navigheaza la pagina precedenta
            await Navigation.PopAsync();
        }
        async void OnDeleteButton1Clicked(object sender, EventArgs e)
        {
            var slist = (Fabricant)BindingContext;
            await App.Database.DeleteFabricantAsync(slist);
            //navigheaza la pagina precedenta
            await Navigation.PopAsync();
        } 
    }
}