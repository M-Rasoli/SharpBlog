using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Core.PostAgg.Dtos
{
    public class CreatePostDto
    {
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImgUrl { get; set; }
    }
}
