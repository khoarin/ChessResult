using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexcel.ChessResult.Data
{
    public class TouramentRound
    {
        [Key]
        public int Id { get; set; }
        public int TouramentId { get; set; }
        public int No { get; set; }
        DateTimeOffset Date { get; set; }
    }
}
