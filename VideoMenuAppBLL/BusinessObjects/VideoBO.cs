using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMenuAppBLL.BusinessObjects
{
    using System.ComponentModel.DataAnnotations;

    public class VideoBO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(4)]
        public string Title { get; set; }

        public int Year { get; set; }


    }
}