using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

namespace VideoMenuAppDAL.Context
{
    using VideoMenuAppDAL.Entities;

    class VideoAppContext : DbContext
    {
        private static DbContextOptions<VideoAppContext> options =
            new DbContextOptionsBuilder<VideoAppContext>().UseInMemoryDatabase("Database").Options;

//         public VideoAppContext()
//         : base(options)
//         {
//         }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
           
                optionsBuilder.UseSqlServer(
                    @"Server=tcp:thom953b.database.windows.net,1433;Initial Catalog=FirstReastAPI;Persist Security Info=False;User ID=thomas;Password=FMA37vtp;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        public DbSet<Video> Videos { get; set; }

        public DbSet<Genre> Genres { get; set; }
    }
}
