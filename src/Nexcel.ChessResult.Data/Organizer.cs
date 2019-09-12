using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexcel.ChessResult.Data
{
    public class Organizer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int FederationId { get; set; }
        public Federation Federation { get; set; }
    }
}
