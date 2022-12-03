using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class CommentDto
    {
        public string Content { get; set; } = string.Empty;
        public int PostId { get; set; }
    }
}
