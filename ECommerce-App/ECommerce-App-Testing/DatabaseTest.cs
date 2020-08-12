using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using ECommerce_App.Data;

namespace ECommerce_App_Testing
{
    public class DatabaseTest : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly StoreDbContext _storeDb;
        protected readonly UserDbContext _userDb;

        public DatabaseTest()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _storeDb = new StoreDbContext(
                new DbContextOptionsBuilder<StoreDbContext>()
                .UseSqlite(_connection)
                .Options);
            _userDb = new UserDbContext(
                new DbContextOptionsBuilder<UserDbContext>()
                .UseSqlite(_connection)
                .Options);

            _storeDb.Database.EnsureCreated();
            _userDb.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _storeDb?.Dispose();
            _userDb?.Dispose();
            _connection?.Close();
        }
    }
}
