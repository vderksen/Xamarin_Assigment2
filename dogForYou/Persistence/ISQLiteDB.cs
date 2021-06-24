using System;
using SQLite;

namespace dogForYou.Persistence
{
    public interface ISQLiteDB
    {
        SQLiteAsyncConnection GetConnection();
    }
}
