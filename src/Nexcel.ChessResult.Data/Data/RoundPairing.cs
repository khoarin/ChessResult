using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexcel.ChessResult.Data
{
    public class RoundPairing
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Index("IX_TournamentRound_Player", IsUnique = true, Order = 1)]
        public int TouramentRoundId { get; set; }
        [Index("IX_TournamentRound_Player", IsUnique = true, Order = 2)]
        public int Player1Id { get; set; }
        [Index("IX_TournamentRound_Player", IsUnique = true, Order = 3)]
        public int Player2Id { get; set; }
        public int? BlackPlayerId { get; set; }
        public int? RoundResult { get; set; }
        public string Score { get; set; }

        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public TournamentRound TouramentRound { get; set; }


    }
}
