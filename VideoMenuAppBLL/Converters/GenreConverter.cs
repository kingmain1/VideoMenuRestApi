using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenuAppBLL.Folders
{
    using VideoMenuAppBLL.BusinessObjects;

    using VideoMenuAppDAL.Entities;

    class GenreConverter
    {
        internal Genre Convert(GenreBO genre)
        {
            if (genre == null)
            {
                return null;
            }

            return new Genre()
                       {
                           Id = genre.Id,
                           GenreName = genre.GenreName,
                           VideoId = genre.VideoId
                       };
        }

        internal GenreBO Convert(Genre genre)
        {
            if (genre == null)
            {
                return null;
            }

            return new GenreBO()
                       {
                           Id = genre.Id,
                           GenreName = genre.GenreName,
                          
                           VideoId = genre.VideoId
            };
        }
    }
}