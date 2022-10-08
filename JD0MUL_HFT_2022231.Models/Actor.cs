using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
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
        public virtual ICollection<TvShow> TvShows{ get; set; }
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
    }
}
