using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordle.Api.Data;

namespace Wordle.Api.Tests
{
    public abstract class DatabaseTestBase
    {
        private AppDbContext? _db;
        public AppDbContext Db
        {
            get
            {
                if (_db == null)
                {
                    var contextOptions = new DbContextOptionsBuilder<AppDbContext>();
                    contextOptions.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CSCD379-2022-Tests;Trusted_Connection=True;MultipleActiveResultSets=true");
                    _db = new AppDbContext(contextOptions.Options);
                    _db.Database.Migrate();
                }
                return _db;
            }
        }
    }
}
