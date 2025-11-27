using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Core.AuthorAgg.Entities;
using App.Domain.Core.PostAgg.Entities;

namespace App.Domain.Core.CategoryAgg.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public List<Post> Posts { get; set; }
    }
}
