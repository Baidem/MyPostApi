using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? EditedDate { get; set; }
        [Column("AuthorId")]
        public int? UserId { get; set; }
        public User? User { get; set; }
        [Required]
        [StringLength(100)]
        public string Content { get; set; }
        public int? PostId { get; set; }
        public Post? Post { get; set; }


    }
}
