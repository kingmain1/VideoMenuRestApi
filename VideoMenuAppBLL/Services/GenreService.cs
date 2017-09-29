using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenuAppBLL.Services
{
    using System.Linq;

    using VideoMenuAppBLL.BusinessObjects;
    using VideoMenuAppBLL.Folders;

    using VideoMenuAppDAL;

    class GenreService : IGenreService
    {
        GenreConverter converter = new GenreConverter();
        VideoConverter vconv = new VideoConverter();

        private DALFacade facade;
        public GenreService(DALFacade facade)
        {
            this.facade = facade;
        }
        public GenreBO CreateGenre(GenreBO genre)
        {
            using (var uow = this.facade.UnitOfWork)
            {
                var newGenre = uow.GenreRepository.CreateGenre(this.converter.Convert(genre));
                uow.Complete();
                return this.converter.Convert(newGenre);
            }
        }

        public List<GenreBO> GetAllGenres()
        {
            using (var uow =this.facade.UnitOfWork)
            {
                 return uow.GenreRepository.GetAllGenres().Select(this.converter.Convert).ToList();
            }
        }

        public GenreBO GetById(int id)
        {
            using (var uow = this.facade.UnitOfWork)
            {
                var genre = uow.GenreRepository.GetById(id);
                var video = uow.VideoRepository.GetById(genre.VideoId);
                var genreBO = this.converter.Convert(genre);
                genreBO.Video = this.vconv.Convert(video);
                return genreBO;
            }
        }

        public GenreBO UpdateGenre(GenreBO genre)
        {
            using (var uow = this.facade.UnitOfWork)
            {
                var selectedGenre = uow.GenreRepository.GetById(genre.Id);
                if (selectedGenre == null)
                {
                    throw new InvalidOperationException("Genre nor found");
                }
                selectedGenre.GenreName = genre.GenreName;
                selectedGenre.VideoId = genre.VideoId;

                var video = uow.VideoRepository.GetById(genre.VideoId);
                uow.Complete();
                var genreBO = this.converter.Convert(selectedGenre);
                genreBO.Video = this.vconv.Convert(video);
                return genreBO;
            }
        }

        public GenreBO DeleteGenre(int Id)
        {
            using (var uow = this.facade.UnitOfWork)
            {
                var deletedGenre = uow.GenreRepository.DeleteGenre(Id);
                uow.Complete();
                return this.converter.Convert(deletedGenre);
            }
        }
    }
}
