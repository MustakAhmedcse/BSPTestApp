using BSPTestWebApp.Models;
using System.Linq;
using System.Web.Http;
using System.Data;
using System.Data.Entity;

namespace BSPTestWebApp.Controllers
{
    public class PostApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [Route("GetPosts")]
        public IHttpActionResult GetPosts()
        {
            var result = db.Posts.Include(p => p.Comments)
                .Select(p => new {
                    Content = p.Content,
                    Creator = p.Creator,
                    CreateDate = p.Creator
                ,
                    Comment = p.Comments.Select(r => new { id = r.Id, CommentText = r.CommentText, Creator = r.Creator,CreateDate=r.CreateDate, Like = r.LikeCounter, Dislike = r.DislikeCounter })
                }).ToList();

            return Ok(new { results = result });

        }
    }
}
