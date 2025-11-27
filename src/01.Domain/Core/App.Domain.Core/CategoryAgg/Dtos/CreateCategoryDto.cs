using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Core.CategoryAgg.Dtos
{
    public class CreateCategoryDto
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
    }
}
