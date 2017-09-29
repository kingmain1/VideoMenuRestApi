using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenuAppBLL.Folders
{
    using VideoMenuAppBLL.BusinessObjects;

    using VideoMenuAppDAL.Entities;

    class VideoConverter
    {
        internal Video Convert(VideoBO video)
        {
            if (video == null)
            {
                return null;
            }
            return new Video() { Id = video.Id, Title = video.Title, Year = video.Year };
        }

        internal VideoBO Convert(Video video)
        {
            if (video == null)
            {
                return null;
            }
            return new VideoBO() { Id = video.Id, Title = video.Title, Year = video.Year };
        }
    }
}
