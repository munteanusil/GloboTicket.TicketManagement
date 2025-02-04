﻿using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {

        public CategoryRepository(GloboTicketDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents)
        {
            var allCotegories = await _dbContext.Categories.Include(x => x.Events).ToListAsync();

            if (!includePassedEvents)
            {
                allCotegories.ForEach(p => p.Events.ToList().RemoveAll(c => c.Date < DateTime.Today));
            }

            return allCotegories;
            
        }
    }
}
