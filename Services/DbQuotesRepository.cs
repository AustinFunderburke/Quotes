using LabW12Quotes.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabW12Quotes.Services
{
    public class DbQuotesRepository : IQuotesRepository
    {
        private QuotesDbContext _db;

        public DbQuotesRepository(QuotesDbContext db)
        {
            _db = db;
        }

        public IQueryable<Quote> ReadAll()
        {
            return _db.Quotes;
        }

        public Quote Create(Quote quote)
        {
            _db.Quotes.Add(quote);
            _db.SaveChanges();
            return quote;
        }

    }
}

