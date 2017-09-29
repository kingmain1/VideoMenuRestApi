using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenuAppBLL
{
    using VideoMenuAppBLL.BusinessObjects;

    public interface IVideoServices
    {
        VideoBO CreateVideo(VideoBO video);

        List<VideoBO> CreateMoreVideos(List<VideoBO> videos);

        List<VideoBO> GetAllVideos();

        VideoBO GetById(int id);

        VideoBO UpdateVideo(VideoBO video);

        VideoBO DeleteVideo(int Id);
    }
}