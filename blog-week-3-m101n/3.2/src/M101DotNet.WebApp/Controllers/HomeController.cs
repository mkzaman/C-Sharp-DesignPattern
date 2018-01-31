using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;
using M101DotNet.WebApp.Models;
using M101DotNet.WebApp.Models.Home;
using MongoDB.Bson;
using System.Linq.Expressions;

namespace M101DotNet.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var blogContext = new BlogContext();
            var recentPosts = await blogContext.Posts.Find(new BsonDocument()).Limit(10).SortBy(x => x.CreatedAtUtc).ToListAsync();
            var model = new IndexModel
            {
                RecentPosts = recentPosts
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult NewPost()
        {
            return View(new NewPostModel());
        }

        [HttpPost]
        public async Task<ActionResult> NewPost(NewPostModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var blogContext = new BlogContext();
            var post = new Post
            {
                Author = this.User.Identity.Name,
                Title = model.Title,
                Content = model.Content,
                CreatedAtUtc = DateTime.UtcNow
            };
            
            List<string> tags = model.Tags.Split(',').ToList<string>();
            post.Tags = tags;

            post.Comments = new List<Comment>();

            await blogContext.Posts.InsertOneAsync(post);

            return RedirectToAction("Post", new { id = post.Id });
        }

        [HttpGet]
        public async Task<ActionResult> Post(string id)
        {
            var blogContext = new BlogContext();

            Post post = await blogContext.Posts.Find(x => string.Equals(x.Id, id)).SingleOrDefaultAsync();

            if (post == null)
            {
                return RedirectToAction("Index");
            }

            var model = new PostModel
            {
                Post = post
            };

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Posts(string tag = "MJy")
        {
            var blogContext = new BlogContext();

            List<Post> posts = await blogContext.Posts.Find(x => x.Tags.Contains(tag)).SortByDescending(x => x.Id).ToListAsync();
            if(posts == null || posts.Count == 0)
            {
                posts = await blogContext.Posts.Find((new BsonDocument())).SortByDescending(x => x.Id).ToListAsync();
            }
            return View(posts);
        }

        [HttpPost]
        public async Task<ActionResult> NewComment(NewCommentModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Post", new { id = model.PostId });
            }

            var blogContext = new BlogContext();

            var doc = new Comment
            {
                Author = this.User.Identity.Name,
                Content = model.Content,
                CreatedAtUtc = DateTime.UtcNow
            };


            var filter = Builders<Post>.Filter.Where(x => x.Id == model.PostId);
            var update = Builders<Post>.Update.Push("Comments", doc);

            await blogContext.Posts.FindOneAndUpdateAsync(filter, update);


            return RedirectToAction("Post", new { id = model.PostId });
        }
    }
}