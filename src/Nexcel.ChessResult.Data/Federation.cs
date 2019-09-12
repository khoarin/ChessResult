using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexcel.ChessResult.Data
{
    public class Federation
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(3)]
        [Required]
        public string ShortName { get; set; }
        [MaxLength(256)]
        [Required]
        public string FullName { get; set; }
        public byte[] Image { get; set; }
    }
}
