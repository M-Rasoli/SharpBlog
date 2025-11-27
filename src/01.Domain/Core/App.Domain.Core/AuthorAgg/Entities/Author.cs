using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Core.CategoryAgg.Entities;
using App.Domain.Core.PostAgg.Entities;

namespace App.Domain.Core.AuthorAgg.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Category> Categories { get; set; }
        public List<Post> Posts { get; set; }
    }
}
