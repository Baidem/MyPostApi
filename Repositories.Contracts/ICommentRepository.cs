using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllCommentsAsync();
        Task<Comment?> GetCommentAsync(int id);
        Task<Comment?> GetCommentWithPostAsync(int id);
        Task<Comment> AddCommentAsync(Comment comment);
        Task<Comment?> ModifyCommentAsync(Comment comment);
        Task<Comment?> RemoveCommentAsync(int id);

    }
}
