using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD0MUL_HFT_2022231.Models.SideClasses
{
    public class ActorInfo
    {
        public string ActorName { get; set; }
        public IEnumerable<string> Titles { get; set; }
        public double Rating { get; set; }
        public override bool Equals(object obj)
        {
            ActorInfo b = obj as ActorInfo;
            if (b == null) return false;
            else
                return this.ActorName == b.ActorName && this.Rating == b.Rating;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.ActorName, this.Rating);
        }
    }
    public class StudioInfo
    {
        public int StudioId { get; set; }
        public string StudioName { get; set; }
        public int ShowNumber { get; set; }
        public IEnumerable<string> TvShowTitles { get; set; }
        public override bool Equals(object obj)
        {
            StudioInfo b = obj as StudioInfo;
            if (b == null) return false;
            else
                return this.StudioName == b.StudioName && this.StudioId == b.StudioId && this.ShowNumber == b.ShowNumber;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.StudioName, this.StudioId, this.ShowNumber);
        }
    }
    public class Best
    {
        public string Title { get; set; }
        public ICollection<Role> Roles { get; set; }
        public override bool Equals(object obj)
        {
            Best b = obj as Best;
            if (b == null) return false;
            else
                return this.Title == b.Title && this.Roles.Count == b.Roles.Count;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Title);
        }
    }
    public class Worst
    {
        public string Title { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public override bool Equals(object obj)
        {
            Worst b = obj as Worst;
            if (b == null) return false;
            else
                return this.Title == b.Title && this.Actors.Count == b.Actors.Count;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Title);
        }
    }
    public class ActorRateInfo
    {
        public string ActorName { get; set; }
        public double avgRating { get; set; }
        public override bool Equals(object obj)
        {
            ActorRateInfo b = obj as ActorRateInfo;
            if (b == null) return false;
            else
                return this.ActorName == b.ActorName && this.avgRating == b.avgRating;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.ActorName);
        }
    }
}
