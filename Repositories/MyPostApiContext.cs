using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class MyPostApiContext : DbContext
    {
        public MyPostApiContext(DbContextOptions<MyPostApiContext> options) 
            : base(options)
        {
        }

        public MyPostApiContext()
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API

            // Default data
            var u1 = new User { Id = 1, FirstName = "Jerry", LastName = "Seinfeld", Email = "Jerry.Seinfeld@aol.com", Password = "password" };
            var u2 = new User { Id = 2, FirstName = "George", LastName = "Costanza", Email = "George.Costanza@aol.com", Password = "george" };
            var u3 = new User { Id = 3, FirstName = "Elaine", LastName = "Benes", Email = "Elaine.Benes@aol.com", Password = "jerry" };
            var u4 = new User { Id = 4, FirstName = "Cosmo", LastName = "Kramer", Email = "Cosmo.Kramer@aol.com", Password = "qzerty" };

            var p1 = new Post { Id = 1, Title = "Les tables à café", Content = "Toute l'histoire des tables à café ...", CreatedDate = DateTime.Now, UserId =  4};
            var p2 = new Post { Id = 2, Title = "Title 2", Content = "Content 2 ...", CreatedDate = DateTime.Now, UserId = 1 };
            var p3 = new Post { Id = 3, Title = "Title 3", Content = "Content 3 ...", CreatedDate = DateTime.Now, UserId = 2 };
            var p4 = new Post { Id = 4, Title = "Title 4", Content = "Content 4 ...", CreatedDate = DateTime.Now, UserId = 3 };

            var c1 = new Comment { Id = 1, Content = "Comment 1 ...", CreatedDate = DateTime.Now, UserId = 2, PostId = 3 };
            var c2 = new Comment { Id = 2, Content = "Comment 2 ...", CreatedDate = DateTime.Now, UserId = 3, PostId = 4 };
            var c3 = new Comment { Id = 3, Content = "Comment 3 ...", CreatedDate = DateTime.Now, UserId = 1, PostId = 2 };
            var c4 = new Comment { Id = 4, Content = "Comment 4 ...", CreatedDate = DateTime.Now, UserId = 4, PostId = 1 };

            modelBuilder.Entity<User>().HasData(new List<User> { u1, u2, u3, u4 });
            modelBuilder.Entity<Post>().HasData(new List<Post> { p1, p2, p3, p4 });
            modelBuilder.Entity<Comment>().HasData(new List<Comment> { c1, c2, c3, c4 });


            base.OnModelCreating(modelBuilder);

        }
    }
}
