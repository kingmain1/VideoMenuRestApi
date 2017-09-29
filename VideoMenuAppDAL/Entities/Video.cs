using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenuAppDAL.Entities
{
    public class Video
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public List<Genre> Genres { get; set; }
    }
}