using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCOtel.Models
{
    public class SliderM
    {
        [Key]
        public int SliderMID { get; set; }
        [Required]
        public string ResimYolu { get; set; }
        public int Sira { get; set; }
    }
}
