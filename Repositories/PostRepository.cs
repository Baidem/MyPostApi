using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class PostRepository : IPostRepository
    {

        MyPostApiContext context;
        ILogger<PostRepository> logger;


        public PostRepository(MyPostApiContext context, ILogger<PostRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await context.Posts.ToListAsync();
        }
        public async Task<Post?> GetPostAsync(int id)
        {
            return await context.Posts.FindAsync(id);
        }
        public async Task<Post?> GetPostWithCommentsAsync(int id)
        {
            return await context.Posts.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Post?> AddPostAsync(Post post)
        {
            try
            {
                await context.Posts.AddAsync(post);

                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.LogError(e?.InnerException?.ToString());

                return null;
            }
            return post;
        }

        public async Task<Post?> ModifyPostAsync(Post param)
        {
            try
            {
                Post? post = await context.Posts.FindAsync(param.Id);
                if (post != null)
                {
                    post.Title = param.Title;
                    post.UserId = param.UserId;
                    post.Content = param.Content;
                    post.Image = param.Image;
                    post.EditedDate = DateTime.Now;

                    await context.SaveChangesAsync();
                    return post;
                }
                else
                {
                    logger.LogError("Item not found");

                    return null;
                }
            }
            catch (Exception e)
            {
                logger.LogError(e?.InnerException?.ToString());

                return null;
            }
        }

        public async Task<Post?> RemovePostAsync(int id)
        {
            try
            {
                Post? post = await context.Posts.FirstOrDefaultAsync(p => p.Id == id);
                if (post != null)
                {
                    context.Posts.Remove(post);

                    await context.SaveChangesAsync();
                    return post;
                }
                else
                {
                    logger.LogError("Item not found");

                    return null;
                }
            }
            catch (Exception e)
            {
                logger.LogError(e?.InnerException?.ToString());

                return null;
            }
        }

        public async Task<Post?> AddPostImageAsync(int idPost, String image)
        {
            var ModifiedPost = await GetPostAsync(idPost);
            if (ModifiedPost == null)
                return null;
            else
            {
                ModifiedPost.Image = image;
                await context.SaveChangesAsync();
                return ModifiedPost;
            }

        }

        public async Task<List<Post>>? GetPostByThemeAsync(string theme)
        {
            var postsByThemes = await context.Posts.Where(p => p.Theme == theme).ToListAsync();
            return postsByThemes;
        }
    }
}




