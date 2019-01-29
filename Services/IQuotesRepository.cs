using LabW12Quotes.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabW12Quotes.Services
{
    public interface IQuotesRepository 
    {
        IQueryable<Quote> ReadAll();
        Quote Create(Quote quote);

    }
}
