using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexcel.ChessResult.Data
{
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ClubId { get; set; }
        public int? FideId { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        public int Rating { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Club Club { get; set; }
        public ICollection<TournamentGroupPlayer> TournamentGroupPlayers { get; set; } = new HashSet<TournamentGroupPlayer>();

    }
}
