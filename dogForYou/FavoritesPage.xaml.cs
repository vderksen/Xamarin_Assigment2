using System;
using System.Collections.Generic;
using Xamarin.Forms;
using SQLite;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;
using dogForYou.Model;

namespace dogForYou
{

    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class FavoritesPage : ContentPage
    {
        public ObservableCollection<Favorites> favorites;
        Favorites favoriteToDelete;
        DBManager dbModel = new DBManager();
  
        public FavoritesPage()
        {
            favorites = new ObservableCollection<Favorites>() { };
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            // get data from data table or create table
            favorites = await dbModel.CreateTable();
            // set list view to the collection favorites 
            favoritesListView.ItemsSource = favorites;
            base.OnAppearing();
        }

        // REMOVE ITEM FROM FAVORITES COLLECION WHEN REMOVE BUTTON IS CLICKED
        async void deleteFromDB(System.Object sender, System.EventArgs e)
        {
            // get selected item to be removed
            favoriteToDelete = ((sender as MenuItem).CommandParameter as Favorites);

            // remove item from collection favorites
            favorites.Remove(favoriteToDelete);

            // remove the item from data base
            dbModel.deleteFavorite(favoriteToDelete);

            await DisplayAlert("Sucess", " Sucessfully Deleted!", "OK");
        }


    }
}
