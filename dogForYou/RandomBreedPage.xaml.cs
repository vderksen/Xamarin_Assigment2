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

    public partial class RandomBreedPage : ContentPage
    {
        public ObservableCollection<Favorites> favorites;
        public NetworkingManager networkingManager = new NetworkingManager();
        DBManager dbModel = new DBManager();

        public RandomBreedPage()
        {
            favorites = new ObservableCollection<Favorites>() { };
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            getBreed();
        }

        // GET NEW RANDOM BREED WHEN NEXT BUTTON IS CLICKED
        void refreshPage(System.Object sender, System.EventArgs e)
        {
            getBreed();
        }

        async void getBreed() {
            // get one random breed from api
            var random = await networkingManager.GetRandomBreed();

            // get image souce from api data object
            Breed_url.Source = random.ElementAt(0).url.ToString();

            // check if data from api has info about breed not just a picture
            if (random.ElementAt(0).Breeds.Count > 0)
            {
                // set to unknown data if there is no info about breed
                if (random.ElementAt(0).Breeds.ElementAt(0).name == null)
                {
                    Breed_name.Text = "Unknown data";
                    temperament.Text = "Unknown data";
                }
                else if (random.ElementAt(0).Breeds.ElementAt(0).temperament == null)
                {
                    Breed_name.Text = random.ElementAt(0).Breeds.ElementAt(0).name.ToString();
                    temperament.Text = "Unknown data";
                }

                // set breed name and temprerament source from api data object
                else
                {
                    Breed_name.Text = random.ElementAt(0).Breeds.ElementAt(0).name.ToString();
                    temperament.Text = random.ElementAt(0).Breeds.ElementAt(0).temperament.ToString();
                }
            }
            else
            {
                Breed_name.Text = "Unknown data";
                temperament.Text = "Unknown data";
            }
            base.OnAppearing();
        }

        // ADD TO FAVORITES COLLECION WHEN LIKE BUTTON IS CLICKED
        async void addToFavorite(System.Object sender, System.EventArgs e)
        {
            // change color and text to like button
            Button button = sender as Button;
            button.Text = "LIKED";
            button.BackgroundColor = Color.Red;

            // create empty object of type Favorites
            Favorites tempFav = new Favorites();

            // set Name, Temprerament, image uri for new favorite object
            tempFav.Name = Breed_name.Text;
            tempFav.Temperament = temperament.Text;
            tempFav.Image = (Uri)Breed_url.Source.GetValue(UriImageSource.UriProperty);

            // add new created favorite object to the collection of favorites object
            favorites.Add(tempFav);

            await DisplayAlert("Sucess", "Added to Favorites", "OK");

            // add new created favorite object to database
            dbModel.insertFavorite(tempFav);

            // change color and text to like button back
            button.Text = "LIKE";
            button.BackgroundColor = Color.HotPink;
        }
    }
}
