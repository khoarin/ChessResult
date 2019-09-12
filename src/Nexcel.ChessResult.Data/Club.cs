﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexcel.ChessResult.Data
{
    public class Club
    {
        [Key]
        public int Id { get; set; }
        public int FederationId { get; set; }
        [MaxLength(256)]
        [Required]
        public string Name { get; set; }

        public Federation Federation { get; set; }
        public ICollection<Player> Players { get; set; } = new HashSet<Player>();
    }
}
