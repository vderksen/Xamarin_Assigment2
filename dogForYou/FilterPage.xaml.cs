using dogForYou.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dogForYou
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilterPage : ContentPage
    {
        public ObservableCollection<BreedData> breedsList;
        public ObservableCollection<Favorites> favorites;
        public NetworkingManager networkingManager = new NetworkingManager();
        BreedData selectedBreed;
        DBManager dbModel = new DBManager();

        public FilterPage()
        {
            favorites = new ObservableCollection<Favorites>() { };
            InitializeComponent();
            BindingContext = this;
        }

        protected async override void OnAppearing()
        {
            dogBreedsList.ItemsSource = null;
            var list = await networkingManager.GetAllBreeds();
            breedsList = new ObservableCollection<BreedData>(list);
            dogBreedsList.ItemsSource = breedsList;
            base.OnAppearing();
        }

        // ADD TO FAVORITES COLLECION WHEN LIKE BUTTON IS CLICKED
        async void Like_Clicked(System.Object sender, System.EventArgs e)
        {
            // create empty object of type Favorites
            Favorites tempFav = new Favorites();

            // get selected breed object
            selectedBreed = ((sender as MenuItem).CommandParameter as BreedData);

            // and save the data of new favorite breed as selected item data
            tempFav.Name = selectedBreed.name;
            tempFav.Temperament = selectedBreed.temperament;
            tempFav.Image = selectedBreed.Image.url;

            // add new created favorite object to the collection of favorites object
            favorites.Add(tempFav);

            await DisplayAlert("Sucess", "Added to Favorites", "OK");

            // add new created favorite object to database
            dbModel.insertFavorite(tempFav);
        }

        // GET USER INPUT AND SEARCH BY MATCHING BREED NAME TO USER INPUT
        void SearchByBreedName(object sender, EventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
            dogBreedsList.ItemsSource = breedsList.Where(value => value.name.ToLowerInvariant().Contains(searchBar.Text)).ToList();
        }


    }
}
