using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCOtel.Models
{
    [Table("tbl_odalar")]
    public class OdaM
    {
        [Key]
        public int OdaMID { get; set; }
        public string Baslik { get; set; }
        public decimal Fiyat { get; set; }
        public int m2 { get; set; }
        public string ResimURL { get; set; }

       
    }
}
