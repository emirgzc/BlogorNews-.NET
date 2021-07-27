using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Subscribe
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }
}
