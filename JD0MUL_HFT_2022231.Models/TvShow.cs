using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace JD0MUL_HFT_2022231.Models
{
    public class TvShow
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TvShowId { get; set; }

        [StringLength(180)]
        public string Title { get; set; }

        [Range(0, 10)]
        public double Rating { get; set; }

        public int ReleaseYear { get; set; }
        public int EndYear { get; set; }

        public int StudioId { get; set; }

        public virtual Studio Studio { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }

        public virtual ICollection<Role> Roles { get; set; }


        public TvShow()
        {

        }

        public TvShow(string line)
        {
            string[] split = line.Split('#');
            TvShowId = int.Parse(split[0]);
            Title = split[1];
            StudioId = int.Parse(split[2]);
            ReleaseYear = int.Parse(split[3]);
            EndYear = int.Parse(split[4]);
            Rating = double.Parse(split[5]);
        }
    }
}
