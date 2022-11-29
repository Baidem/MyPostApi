using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Theme { get; set; }
        public User Author { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EditedDate { get; set; }
        public string Content { get; set; }
        public List<Comment> Comments { get; set; }
        public string Image { get; set; }
        public User User { get; set; }

    }   
}
