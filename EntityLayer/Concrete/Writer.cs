using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Job { get; set; }
        [StringLength(50)]
        public string Country { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string DateOfBirth { get; set; }
        [StringLength(50)]
        public string Image { get; set; }
        [StringLength(50)]
        public string Password { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}
