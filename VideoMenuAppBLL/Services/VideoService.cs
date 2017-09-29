using System;
using System.Collections.Generic;
using System.Linq;

using VideoMenuAppDAL;


namespace VideoMenuAppBLL.Services
{
    using System.Linq;

    using VideoMenuAppBLL.BusinessObjects;
    using VideoMenuAppBLL.Folders;

    using VideoMenuAppDAL.Entities;

    class VideoService : IVideoServices
    {
        private VideoConverter videoConverter = new VideoConverter();
        private DALFacade facade;

        public VideoService(DALFacade dalFacade)
        {
            this.facade = dalFacade;
        }

        public VideoBO CreateVideo(VideoBO video)
        {
            using (var uow = this.facade.UnitOfWork)
            {
                var newVideo = uow.VideoRepository.CreateVideo(this.videoConverter.Convert(video));
                uow.Complete();
                return this.videoConverter.Convert(newVideo);
            }
        }

        public List<VideoBO> CreateMoreVideos(List<VideoBO> videos)
        {
            using (var uow = this.facade.UnitOfWork)
            {
                foreach (var video in videos)
                {
                    uow.VideoRepository.CreateVideo(this.videoConverter.Convert(video));
                }

                uow.Complete();
                return videos;
            }
        }

        public VideoBO DeleteVideo(int id)
        {
            using (var uow = this.facade.UnitOfWork)
            {
                var deletedVideo = uow.VideoRepository.DeleteVideo(id);
                uow.Complete();
                return this.videoConverter.Convert(deletedVideo);
            }
        }

        public List<VideoBO> GetAllVideos()
        {
            using (var uow = this.facade.UnitOfWork)
            {
                return uow.VideoRepository.GetAllVideos().Select(v => this.videoConverter.Convert(v)).ToList();
            }
        }

        public VideoBO GetById(int id)
        {
            using (var uow = this.facade.UnitOfWork)
            {
                return this.videoConverter.Convert(uow.VideoRepository.GetById(id));
            }
        }

        public VideoBO UpdateVideo(VideoBO video)
        {
            using (var uow = this.facade.UnitOfWork)
            {
                var updatedVideo = uow.VideoRepository.GetById(video.Id);
                if (updatedVideo == null)
                {
                    throw new InvalidOperationException("Video not found");
                }

                updatedVideo.Title = video.Title;
                updatedVideo.Year = video.Year;
                uow.Complete();
                return this.videoConverter.Convert(updatedVideo);
            }
        }


    }
}