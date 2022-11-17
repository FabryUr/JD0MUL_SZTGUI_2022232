using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JD0MUL_HFT_2022231.Models
{
    public class Actor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActorId { get; set; }
        [Required]
        [StringLength(180)]
        public string ActorName { get; set; }
        [JsonIgnore]
        public virtual ICollection<TvShow> TvShows{ get; set; }
        [JsonIgnore]
        public virtual ICollection<Role> Roles { get; set; }
        public Actor()
        {

        }
        public Actor(string line)
        {
            string[] split = line.Split('#');
            ActorId = int.Parse(split[0]);
            ActorName = split[1];
        }

        public override bool Equals(object obj)
        {
            Actor b = obj as Actor;
            if(b== null) return false;
            else
                return this.ActorName==b.ActorName && this.ActorId==b.ActorId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.ActorName, this.ActorId);
        }
    }
}
