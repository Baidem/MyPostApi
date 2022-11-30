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
    public class CommentRepository : ICommentRepository
    {
        MyPostApiContext context;
        ILogger<CommentRepository> logger;

        public CommentRepository(MyPostApiContext context, ILogger<CommentRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public async Task<List<Comment>> GetAllCommentsAsync()
        {
            return await context.Comments.ToListAsync();
        }
        public async Task<Comment?> GetCommentAsync(int id)
        {
            return await context.Comments.FindAsync(id);
        }
        public async Task<Comment?> GetCommentWithPostAsync(int id)
        {
            return await context.Comments.Include(p => p.Post).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Comment?> AddCommentAsync(Comment comment)
        {
            try
            {
                await context.Comments.AddAsync(comment);

                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.LogError(e?.InnerException?.ToString());

                return null;
            }
            return comment;
        }

        public async Task<Comment?> ModifyCommentAsync(Comment param)
        {
            try
            {
                Comment? comment = await context.Comments.FindAsync(param.Id);
                if (comment != null)
                {
                    comment.UserId = param.UserId;
                    comment.Content = param.Content;
                    comment.EditedDate = DateTime.Now;

                    await context.SaveChangesAsync();
                    return comment;
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

        public async Task<Comment?> RemoveCommentAsync(int id)
        {
            try
            {
                Comment? comment = await context.Comments.FirstOrDefaultAsync(p => p.Id == id);
                if (comment != null)
                {
                    context.Comments.Remove(comment);

                    await context.SaveChangesAsync();
                    return comment;
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

    }
}
