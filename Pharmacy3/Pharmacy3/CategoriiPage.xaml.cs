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
    public partial class CategoriiPage : ContentPage
    {
        public CategoriiPage()
        {
            InitializeComponent();
        }
       
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var slist = (Categorie)BindingContext;
            await App.Database.SaveCategorieAsync(slist);
            //navigheaza la pagina precedenta
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var slist = (Categorie)BindingContext;
            await App.Database.DeleteCategorieAsync(slist);
            //navigheaza la pagina precedenta
            await Navigation.PopAsync();
        } /**/
    }
}