using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexcel.ChessResult.Data
{
    public class TournamentGroup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Index("IX_Tournament_CompetitonType", IsUnique = true, Order = 1)]
        public int TournamentId { get; set; }
        [Index("IX_Tournament_CompetitonType", IsUnique = true, Order = 2)]
        public int CompetitionTypeId { get; set; }
        [Index("IX_Tournament_CompetitonType", IsUnique = true, Order = 3)]
        [MaxLength(256)]
        public string Name { get; set; }
        public string Description { get; set; }

        public Tournament Tournament { get; set; }
        public CompetitionType CompetitionType { get; set; }
    }
}
