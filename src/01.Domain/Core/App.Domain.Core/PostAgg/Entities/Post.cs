using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Core.AuthorAgg.Entities;
using App.Domain.Core.CategoryAgg.Entities;
using App.Domain.Core.CommentAgg.Entities;

namespace App.Domain.Core.PostAgg.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImgUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedAtShamsi { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
