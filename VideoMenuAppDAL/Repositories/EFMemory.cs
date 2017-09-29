using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenuAppDAL.Repositories
{
    using System.Linq;

    using VideoMenuAppDAL.Context;
    using VideoMenuAppDAL.Entities;

    class EFMemory : IVideoRepository
    {
        private VideoAppContext context;

        public EFMemory(VideoAppContext context)
        {
            this.context = context;
        }
        public Video CreateVideo(Video video)
        {
            context.Videos.Add(video);
            return video;
        }

        public List<Video> GetAllVideos()
        {
            return this.context.Videos.ToList();
        }

        public Video GetById(int id)
        {
            return this.context.Videos.FirstOrDefault(x => x.Id == id);
        }

        public Video DeleteVideo(int Id)
        {
            var selectedVideo = GetById(Id);
            this.context.Videos.Remove(selectedVideo);
            return selectedVideo;
        }
    }
}
