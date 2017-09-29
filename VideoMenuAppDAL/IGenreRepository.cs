using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenuAppDAL
{
    using VideoMenuAppDAL.Entities;

    public interface IGenreRepository
    {
        Genre CreateGenre(Genre genre);

        List<Genre> GetAllGenres();

        Genre GetById(int id);


        Genre DeleteGenre(int Id);
    }
}
