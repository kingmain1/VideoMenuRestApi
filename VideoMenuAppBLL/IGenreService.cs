using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenuAppBLL
{
    using VideoMenuAppBLL.BusinessObjects;

    public interface IGenreService
    {
        GenreBO CreateGenre(GenreBO genre);


        List<GenreBO> GetAllGenres();

        GenreBO GetById(int id);

        GenreBO UpdateGenre(GenreBO genre);

        GenreBO DeleteGenre(int Id);
    }
}
