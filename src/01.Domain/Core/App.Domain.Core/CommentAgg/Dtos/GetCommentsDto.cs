using System;
using System.Collections.Generic;
using System.Text;
using App.Domain.Core.CommentAgg.Enums;

namespace App.Domain.Core.CommentAgg.Dtos
{
    public class GetCommentsDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Rate { get; set; }
        public string CommentText { get; set; }
        public int PostId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string PostTitle { get; set; }
        public CommentStatusEnum Status { get; set; }
    }
}
