using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime EditedDate { get; set; }
        [Required]
        public int AuthorId { get; set; }
        public User Author { get; set; }
        [Required]
        public string Content { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }


    }
}
