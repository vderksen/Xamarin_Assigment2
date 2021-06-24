using System;
using System.IO;
using dogForYou;
using SQLite;
using dogForYou.Droid;
using Xamarin.Forms;
using dogForYou.Persistence;

[assembly: Dependency(typeof(SQLiteDB))]

namespace dogForYou.Droid
{
    public class SQLiteDB : ISQLiteDB
	{
		public SQLiteAsyncConnection GetConnection()
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			var path = Path.Combine(documentsPath, "MyDB.db3");

			return new SQLiteAsyncConnection(path);
		}
	}
}

