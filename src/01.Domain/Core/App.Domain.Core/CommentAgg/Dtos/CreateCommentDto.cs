using App.Domain.Core.PostAgg.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Core.CommentAgg.Dtos
{
    public class CreateCommentDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Rate { get; set; }
        public string CommentText { get; set; }
        public int PostId { get; set; }
    }
}
