using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Settings
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string DirectorName { get; set; }
        [StringLength(300)]
        public string Map { get; set; }
        [StringLength(50)]
        public string Facebook { get; set; }
        [StringLength(50)]
        public string Twitter { get; set; }
        [StringLength(50)]
        public string Instagram { get; set; }
        [StringLength(50)]
        public string Linkedin { get; set; }
        [StringLength(50)]
        public string Youtube { get; set; }
    }
}
