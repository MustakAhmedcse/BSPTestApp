using BSPTestWebApp.Models;
using System.Linq;
using System.Web.Http;
using System.Data;
using System.Data.Entity;
using PTestWebApi.Models;

namespace BSPTestWebApp.Controllers
{
    public class PostApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [Route("GetPosts")]
        public IHttpActionResult GetPosts()
        {
            var result = db.Posts.Include(p => p.Comments)
                .Select(p => new
                {
                    Content = p.Content,
                    Creator = p.Creator,
                    CreateDate = p.Creator
                ,
                    Comment = p.Comments.Select(r => new { id = r.Id, CommentText = r.CommentText, Creator = r.Creator, CreateDate = r.CreateDate, Like = r.LikeCounter, Dislike = r.DislikeCounter })
                }).ToList();

            return Ok(new { results = result });

        }

        [Route("GetPosts")]
        public IHttpActionResult CountLikeDislike(int isLike, int commentId)
        {
            Comment comment = new Comment();
            comment = db.Comments.Find(commentId);
            if (isLike == 1)
                comment.LikeCounter++;
            else
                comment.DislikeCounter++;
            db.Entry(comment).State = EntityState.Modified;
            db.SaveChanges();
            return Ok();

        }
    }
}
