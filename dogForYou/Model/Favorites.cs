using System;
using SQLite;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace dogForYou.Model
{
    public class Favorites : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Temperament { get; set; }
        public Uri Image { get; set; }
    }
}
