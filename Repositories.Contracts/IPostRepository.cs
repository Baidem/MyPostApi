using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IPostRepository
    {
        Task<List<Post>> GetAllPostsAsync();
        Task<Post?> GetPostAsync(int id);
        Task<Post?> GetPostWithCommentsAsync(int id);
        Task<Post> AddPostAsync(Post post);
        Task<Post?> ModifyPostAsync(Post post);
    }
}
