using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexcel.ChessResult.Data
{
    public class TournamentRound
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Index("IX_TournamentGroup_RoundNo", IsUnique = true, Order = 1)]
        public int TournamentGroupId { get; set; }
        [Index("IX_TournamentGroup_RoundNo", IsUnique = true, Order = 2)]
        public int No { get; set; }
        DateTimeOffset Date { get; set; }
        public bool IsLastRound { get; set; }

        public TournamentGroup TournamentGroup { get; set; }
        public ICollection<RoundPairing> RoundPairings { get; set; }
    }
}
