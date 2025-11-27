using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Core.PostAgg.Dtos
{
    public class GetPostsByAuthorId
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string? ImgUrl { get; set; }
        public string CreatedAtShamsi { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Category { get; set; }
    }
}
