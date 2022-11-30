﻿using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace MyPostApi.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        IPostRepository postRepository;
        public PostController(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
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

    }
}