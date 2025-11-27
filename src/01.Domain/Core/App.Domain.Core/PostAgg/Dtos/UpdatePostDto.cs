using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Core.PostAgg.Dtos
{
    public class UpdatePostDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string? ImgUrl { get; set; }
    }
}
