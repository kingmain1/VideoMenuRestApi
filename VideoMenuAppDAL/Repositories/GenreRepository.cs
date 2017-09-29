using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenuAppDAL.Repositories
{
    using System.Linq;

    using Microsoft.EntityFrameworkCore;

    using VideoMenuAppDAL.Context;
    using VideoMenuAppDAL.Entities;

    class GenreRepository : IGenreRepository
    {
        private VideoAppContext context;
        public GenreRepository(VideoAppContext context)
        {
            this.context = context;
        }
        public Genre CreateGenre(Genre genre)
        {
         
            this.context.Genres.Add(genre);
            return genre;
        }

        public List<Genre> GetAllGenres()
        {
            return this.context.Genres.ToList();
        }

        public Genre GetById(int id)
        {

            return this.context.Genres.FirstOrDefault(g => g.Id == id);
        }

        public Genre DeleteGenre(int Id)
        {
            var genre = GetById(Id);
            this.context.Genres.Remove(genre);
            return genre;
        }
    }
    }
