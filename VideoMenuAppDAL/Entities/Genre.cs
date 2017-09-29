using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenuAppDAL.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        public string GenreName { get; set; }

        public Video Video { get; set; }

        public int VideoId { get; set; }    

    }
}
