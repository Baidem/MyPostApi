using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Repositories;
using Repositories.Contracts;

namespace MyPostApi.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        IWebHostEnvironment environment;

        IPostRepository postRepository;
        public PostController(IPostRepository postRepository, IWebHostEnvironment environment)
        {
            this.postRepository = postRepository;
            this.environment = environment;
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetAllPosts()
        {
            var posts = await postRepository.GetAllPostsAsync();

            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await postRepository.GetPostAsync(id);

            return Ok(post);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPostWithComments(int id)
        {
            var post = await postRepository.GetPostWithCommentsAsync(id);

            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult<Post>> AddPost(Post post)
        {
            var postCreated = await postRepository.AddPostAsync(post);

            if (postCreated != null)
                return Ok(postCreated);
            else
                return Problem("Post not created");
        }

        [HttpPut]
        public async Task<ActionResult<Post>> ModifyPost(Post param)
        {
            var postModified = await postRepository.ModifyPostAsync(param);

            if (postModified != null)
                return Ok(postModified);
            else
                return Problem("Post not modified");
        }

        [HttpDelete]
        public async Task<ActionResult<Post>> RemovePost(int id)
        {
            var postRemoved = await postRepository.RemovePostAsync(id);
            if (postRemoved != null)
                return Ok(postRemoved);
            else
                return Problem("Post not removed");
        }
        [HttpPost]
        public async Task<IActionResult> AddPostImage([FromForm] AddPostImageModel addPostImageModel)
        {
            if (addPostImageModel != null && addPostImageModel.PostId != null && addPostImageModel.Image != null)
            {
                await postRepository.AddPostImageAsync(addPostImageModel.PostId, addPostImageModel.Image.FileName);
            }
            if (!string.IsNullOrEmpty(addPostImageModel.Image?.FileName) && addPostImageModel.Image.FileName.Length > 0)
            {
                var path = Path.Combine(environment.WebRootPath, "Images/", addPostImageModel.Image.FileName); using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await addPostImageModel.Image.CopyToAsync(stream); stream.Close();
                }
            }

            return Ok(addPostImageModel);
        }
        [HttpGet]
        public async Task<ActionResult<List<Post>>>? GetPostsByTheme(string theme)
        {
            var postsByThemes = await postRepository.GetPostByThemeAsync(theme);

            return postsByThemes;
        }
    }
}
