using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexcel.ChessResult.Data
{
    public class TournamentGroupPlayer
    {
        [Key]
        [Column(Order =1)]
        public int TournamentGroupId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int PlayerId { get; set; }

        public TournamentGroup TournamentGroup { get; set; }
        public Player Player { get; set; }
        public int StartRating { get; set; }
    }
}
