using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace JD0MUL_HFT_2022231.Models
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public int TvShowId { get; set; }
        public int ActorId { get; set; }

        public virtual Actor Actor { get; private set; }
        [JsonIgnore]
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
            RoleName = split[3];
        }
        public override bool Equals(object obj)
        {
            Role b = obj as Role;
            if (b == null) return false;
            else
                return this.RoleName == b.RoleName && this.RoleId == b.RoleId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.RoleName, this.RoleId);
        }
    }
}
