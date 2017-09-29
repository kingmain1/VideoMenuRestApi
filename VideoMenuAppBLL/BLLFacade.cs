using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenuAppBLL
{
    using VideoMenuAppBLL.Services;

    using VideoMenuAppDAL;

    public class BLLFacade
    {
        public IVideoServices GetVideoService()
        {
            return new VideoService(new DALFacade());
        }

        public IGenreService GetGenreService()
        {
            return new GenreService(new DALFacade());
        }
    }
}
