using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD0MUL_HFT_2022231.Models
{
    public class Creator
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CreatorId { get; set; }

        [Required]
        [StringLength(240)]
        public string DirectorName { get; set; }

        public virtual ICollection<TvShow> TvShows { get; set; }

        public Creator()
        {
            TvShows = new HashSet<TvShow>();
        }

        public Creator(string line)
        {
            string[] split = line.Split('#');
            CreatorId = int.Parse(split[0]);
            DirectorName = split[1];
            TvShows = new HashSet<TvShow>();
        }
    }
}
