namespace VideoMenuAppDAL
{
    using System.Collections.Generic;

    using VideoMenuAppDAL.Entities;

    public interface IVideoRepository
    {
        Video CreateVideo(Video video);

        List<Video> GetAllVideos();

        Video GetById(int id);


        Video DeleteVideo(int Id);

    }
}