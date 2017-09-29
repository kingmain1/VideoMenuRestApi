using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenuAppDAL
{
    public interface IUnitOfWork : IDisposable
    {
        IVideoRepository VideoRepository { get; }
        IGenreRepository GenreRepository { get; }

        int Complete(); 
    }
}
