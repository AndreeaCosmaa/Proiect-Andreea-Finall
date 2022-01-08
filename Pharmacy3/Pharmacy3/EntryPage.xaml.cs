using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pharmacy3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryPage : ContentPage
    {
        public EntryPage()
        {
            InitializeComponent();
        }
        async void OnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListEntryPage{});
        }
        
        async void OnButton2Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListEntryFabricantPage{});
        }
        async void OnButton3Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListEntryMedicamentPage { });
        }
    }
}