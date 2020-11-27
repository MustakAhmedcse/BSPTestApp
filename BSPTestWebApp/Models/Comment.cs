using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PTestWebApi.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string CommentText { get; set; }
        public string Creator { get; set; }
        public DateTime CreateDate { get; set; }
        public int LikeCounter { get; set; }
        public int DislikeCounter { get; set; }
        [ForeignKey("Post")]
        public int PostId { get; set; }
        public  Post Post { get; set; }
    }
}