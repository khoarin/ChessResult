﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexcel.ChessResult.Data
{
    public class Tournament
    {
        [Key]
        public int Id { get; set; }

        public int OrganizerId { get; set; }
        
        [MaxLength(256)]
        [Required]
        public string Name { get; set; }
        [MaxLength(256)]
        public string TournamentDirector { get; set; }
        [MaxLength(256)]
        public string ChiefArbiter { get; set; }
        public string TimeControl { get; set; }
        public string Location { get; set; }
        public string RatingCaculation { get; set; }
        public DateTimeOffset FromDate { get; set; }
        public DateTimeOffset ToDate { get; set; }

        public Organizer Organizer { get; set; }
        public ICollection<PairingProgram> PairingPrograms { get; set; } = new HashSet<PairingProgram>();

    }
}
