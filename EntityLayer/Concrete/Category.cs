using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CatId { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        public bool Status { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}
