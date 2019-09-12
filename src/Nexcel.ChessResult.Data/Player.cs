using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexcel.ChessResult.Data
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public int ClubId { get; set; }
        public int? FideId { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        public int Rating { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Club Club { get; set; }

    }
}
