using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Theme { get; set; }
        [Column("AuthorId")]
        public int? UserId { get; set; }
        public User? User { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? EditedDate { get; set; }
        public string? Content { get; set; }
        public List<Comment>? Comments { get; set; }
        public string? Image { get; set; }

    }   
}
