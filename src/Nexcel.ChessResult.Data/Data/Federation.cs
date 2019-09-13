using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexcel.ChessResult.Data
{
    public class Federation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(3)]
        [Required]
        public string Name { get; set; }
        [MaxLength(256)]
        [Required]
        public string FullName { get; set; }
        public byte[] Image { get; set; }
    }
}
