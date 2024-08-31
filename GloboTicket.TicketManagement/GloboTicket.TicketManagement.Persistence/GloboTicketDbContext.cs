using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Domain.Common;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Persistence
{
    public class GloboTicketDbContext : DbContext
    {
        public readonly ILoggedInUserService _loggedInUserService;

        public GloboTicketDbContext(DbContextOptions<GloboTicketDbContext> options) : base(options)
        {
            
        }


        public GloboTicketDbContext(DbContextOptions<GloboTicketDbContext> options, ILoggedInUserService loggedInUserService)
             : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }
        public DbSet<Event> Events { get; set; }

        public DbSet<Category> Categories { get; set; }


        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GloboTicketDbContext).Assembly);

            //seed data, added through migrations
            var concertGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var musicalGuid = Guid.Parse("{B0944D2F-8003-43C1-92A4-EDC76A7C5DDE}"); // Problema este aici
            var playGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var conferenceGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = concertGuid,
                Name = "Concerts"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = musicalGuid,
                Name = "Musicals"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = playGuid,
                Name = "Plays"
            });
            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}"),
                Name = "50 Cent in Bucharest",
                Price = 85,
                Artist = "50 Cent",
                Date = DateTime.Now.AddMonths(6),
                Description = "The singer will perform live some of the most famous hits, such as \"In Da Club\", \"Candy Shop\", \"Just a Lil Bit\", creating an incendiary atmosphere in a large-scale production offering an immersive and memorable show!",
                ImageUrl = "https://en.wikipedia.org/wiki/File:50_Cent_in_2018.png",
                CategoryId = concertGuid,

            }) ;

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
                Name = "The Death of Slim Shady",
                Price = 79,
                Artist = "Eminem",
                Date = DateTime.Now.AddMonths(2),
                Description = "The themes of The Eminem Show are predominantly based on Eminem's prominence in hip hop culture and the subsequent envy towards him, as well as his thoughts on his unexpected enormous success and its consequential negative effects on his life",
                ImageUrl = "https://lastfm.freetls.fastly.net/i/u/770x0/09898871d5dacd41cc41574b0c053647.jpg#09898871d5dacd41cc41574b0c053647",
                CategoryId = concertGuid
            }) ;

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("{B419A7CA-3321-4F38-BE8E-4D7B6A529319}"),
                Name = "Las Mujeres Ya No Lloran World Tour",
                Price = 84,
                Artist = "Shakira",
                Date = DateTime.Now.AddMonths(3),
                Description = "The tour, in support of her new album of the same name, will kick off Nov. 2 in Palm Desert, California, and wrap on Dec. 15 in Detroit, Michigan. e 14-arena trek, she will also visit Los Angeles, Miami, and New York City, to name a few.",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTa-HHyNebTjhes5UyHvHEI6cELb2TeS_vfQQ&s",
                CategoryId = concertGuid
            }) ;
                       
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }


    }
}
