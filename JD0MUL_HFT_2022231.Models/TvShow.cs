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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TvShowId { get; set; }

        [StringLength(180)]
        public string Title { get; set; }

        [Range(0, 10000)]
        public double Income { get; set; }

        [Range(0, 10)]
        public double Rating { get; set; }

        public DateTime Release { get; set; }

        public int CreatorId { get; set; }

        public virtual Creator Creator { get; set; }

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
            Income = double.Parse(split[2]);
            CreatorId = int.Parse(split[3]);
            Release = DateTime.Parse(split[4].Replace('*', '.'));
            Rating = double.Parse(split[5]);
        }
    }
}
