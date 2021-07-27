using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        public string Value { get; set; }
        public DateTime BlogDate { get; set; }
        [StringLength(50)]
        public string Image { get; set; }
        public int BlogRating { get; set; }
        public bool Status { get; set; }

        public int CatId { get; set; }
        public virtual Category Category { get; set; }

        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
