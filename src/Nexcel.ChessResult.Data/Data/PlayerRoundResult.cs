using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexcel.ChessResult.Data
{
    public class PlayerRoundResult
    {
        [Key]
        [Column(Order =1)]
        public int PlayerId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int RoundPairingId { get; set; }
        public float Point { get; set; } = 0;

        public RoundPairing RoundPairing { get; set; }
        public Player Player { get; set; }
    }
}
