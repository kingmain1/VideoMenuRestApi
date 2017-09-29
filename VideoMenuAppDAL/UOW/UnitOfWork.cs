using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenuAppDAL.UOW
{
    using VideoMenuAppDAL.Context;
    using VideoMenuAppDAL.Repositories;

    class UnitOfWork : IUnitOfWork
    {
        public IVideoRepository VideoRepository { get; internal set; }

        public IGenreRepository GenreRepository { get; internal set; }

        private VideoAppContext context;

        public UnitOfWork()
        {
            this.context = new VideoAppContext();
            this.context.Database.EnsureCreated();
            VideoRepository = new EFMemory(this.context);
            GenreRepository = new GenreRepository(this.context);
        }

        public int Complete()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}