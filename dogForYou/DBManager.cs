using dogForYou.Model;
using dogForYou.Persistence;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace dogForYou
{
    public class DBManager
    {
        private SQLiteAsyncConnection _connection;

        public DBManager()
        {
            _connection = DependencyService.Get<ISQLiteDB>().GetConnection();
        }

        public async Task<ObservableCollection<Favorites>> CreateTable()
        {
            await _connection.CreateTableAsync<Favorites>();
            var fav = await _connection.Table<Favorites>().ToListAsync();
            var _fav = new ObservableCollection<Favorites>(fav);
            return _fav;
        }

        public void insertFavorite(Favorites fav)
        {
            _connection.InsertAsync(fav);
        }

        public void deleteFavorite(Favorites fav)
        {
            _connection.DeleteAsync(fav);
        }

        public void updateFavorite(Favorites fav)
        {
            _connection.UpdateAsync(fav);

        }
    }
}
