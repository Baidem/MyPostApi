using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace MyPostApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("[controller]/[Action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        ICommentRepository commentRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commentRepository"></param>
        public CommentController(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Comment>>> GetAllComments()
        {
            var comments = await commentRepository.GetAllCommentsAsync();

            return Ok(comments);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            var comment = await commentRepository.GetCommentAsync(id);

            return Ok(comment);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetCommentWithPost(int id)
        {
            var comment = await commentRepository.GetCommentWithPostAsync(id);

            return Ok(comment);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Comment>> AddComment(Comment comment)
        {
            var commentCreated = await commentRepository.AddCommentAsync(comment);

            if (commentCreated != null)
                return Ok(commentCreated);
            else
                return Problem("Comment not created");
        }
        [HttpPut]
        public async Task<ActionResult<Comment>> ModifyComment(Comment param)
        {
            var commentModified = await commentRepository.ModifyCommentAsync(param);

            if (commentModified != null)
                return Ok(commentModified);
            else
                return Problem("Comment not modified");
        }
        [HttpDelete]
        public async Task<ActionResult<Comment>> RemoveComment(int id)
        {
            var commentRemoved = await commentRepository.RemoveCommentAsync(id);
            if (commentRemoved != null)
                return Ok(commentRemoved);
            else
                return Problem("Comment not removed");
        }
    }
}
