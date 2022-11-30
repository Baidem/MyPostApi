using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class PostRepository : IPostRepository
    {
        MyPostApiContext context;
        ILogger<PostRepository> logger;

        public PostRepository(MyPostApiContext context, ILogger<PostRepository> logger )
        {
            this.context = context;
            this .logger = logger;
        }
        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await context.Posts.ToListAsync();
        }
        public async Task<Post?> GetPostAsync(int id)
        {
            return await context.Posts.FindAsync(id);
        }
        public  Task<Post?> GetPostWithCommentsAsync(int id)
        {
            return context.Posts.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Post?> AddPostAsync(Post post)
        {
            try
            {
                context.Posts.Add(post);

                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.LogError(e?.InnerException?.ToString());

                return null;
            }
            return post;
        }
    }
}




