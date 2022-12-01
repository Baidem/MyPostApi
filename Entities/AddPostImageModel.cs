using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;


namespace Entities
{
    public class AddPostImageModel
    {
        public IFormFile Image { get; set; }
        public int PostId { get; set; }
    }
}
