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
    public class Studio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudioId { get; set; }

        [Required]
        [StringLength(240)]
        public string StudioName { get; set; }
        [JsonIgnore]
        public virtual ICollection<TvShow> TvShows { get; set; }

        public Studio()
        {
            TvShows = new HashSet<TvShow>();
        }

        public Studio(string line)
        {
            string[] split = line.Split('#');
            StudioId = int.Parse(split[0]);
            StudioName = split[1];
            TvShows = new HashSet<TvShow>();
        }
    }
}
