using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace dogForYou
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // NAVIGATION TO ALL BREEDS PAGE
        async void allBreedsPage(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new FilterPage());
        }

        // NAVIGATION TO RANDOM BREED PAGE
        async void filterPage(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new RandomBreedPage());
        }

        // NAVIGATION TO FAVORITE BREEDS PAGE
        async void favoritesPage(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new FavoritesPage());
        }

    }
}
