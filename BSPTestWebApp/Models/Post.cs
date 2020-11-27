using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PTestWebApi.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public string Creator { get; set; }
        public DateTime CreateDate { get; set; }

        public  List<Comment> Comments { get; set; }
    }
}