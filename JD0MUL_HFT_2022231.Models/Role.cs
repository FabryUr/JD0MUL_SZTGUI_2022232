using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD0MUL_HFT_2022231.Models
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }

        public int Priority { get; set; }
        public string RoleName { get; set; }

        public int TvShowId { get; set; }
        public int ActorId { get; set; }

        public virtual Actor Actor { get; private set; }
        public virtual TvShow TvShow { get; private set; }

        public Role()
        {

        }

        public Role(string line)
        {
            string[] split = line.Split('#');
            RoleId = int.Parse(split[0]);
            TvShowId = int.Parse(split[1]);
            ActorId = int.Parse(split[2]);
            Priority = int.Parse(split[3]);
            RoleName = split[4];
        }
    }
}
