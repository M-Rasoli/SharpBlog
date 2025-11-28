using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Core.CommentAgg.Enums;
using App.Domain.Core.PostAgg.Entities;

namespace App.Domain.Core.CommentAgg.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Rate { get; set; }
        public string CommentText { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
        public CommentStatusEnum Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
