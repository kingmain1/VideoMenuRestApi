using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenuAppBLL.BusinessObjects
{
    public class GenreBO
    {
        public int Id { get; set; }

        public string GenreName { get; set; }

        public int VideoId { get; set; }

        public VideoBO Video { get; set; }
    }
}