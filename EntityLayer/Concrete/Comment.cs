using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Surname { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public string Value { get; set; }
        public DateTime CommentDate { get; set; }
        public int BlogRating { get; set; }
        public bool Status { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blogs { get; set; }
    }
}
