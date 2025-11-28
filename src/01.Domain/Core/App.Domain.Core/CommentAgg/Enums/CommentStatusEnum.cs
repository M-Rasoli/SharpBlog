using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Domain.Core.CommentAgg.Enums
{
    public enum CommentStatusEnum
    {
        [Display(Name = "تایید شده")]
        Confirmed = 1,
        [Display(Name = "در انتظار")]
        Pending = 2,
        [Display(Name = "رد شده")]
        Denied = 3,
    }
}
