using JD0MUL_HFT_2022231.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace JD0MUL_HFT_2022231.Repository
{
    public class TvShowDbContext : DbContext
    {
        public DbSet<TvShow> TvShows { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public TvShowDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseLazyLoadingProxies().UseInMemoryDatabase("tvShow");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TvShow>(tvShow => tvShow
            .HasOne(tvShow => tvShow.Studio)
            .WithMany(studio => studio.TvShows)
            .HasForeignKey(tvShow => tvShow.StudioId)
            .OnDelete(DeleteBehavior.Cascade));


            modelBuilder.Entity<Actor>()
                .HasMany(x => x.TvShows)
                .WithMany(x => x.Actors)
                .UsingEntity<Role>(
                x => x.HasOne(x => x.TvShow)
                .WithMany().HasForeignKey(x => x.TvShowId).OnDelete(DeleteBehavior.Cascade),
                x => x.HasOne(x => x.Actor)
                .WithMany().HasForeignKey(x => x.ActorId).OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Role>()
                .HasOne(r => r.Actor)
                .WithMany(actor => actor.Roles)
                .HasForeignKey(r => r.ActorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Role>()
                .HasOne(r => r.TvShow)
                .WithMany(movie => movie.Roles)
                .HasForeignKey(r => r.TvShowId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TvShow>().HasData(new TvShow[]
            {
                new TvShow("1#Chernobyl#1#2019#2019#9,4"),
                new TvShow("2#The Crown#2#2016#2069#8,7"),
                new TvShow("3#Stranger Things#2#2016#2069#8,7"),
                new TvShow("4#House of Cards#2#2013#2018#8,7"),
                new TvShow("5#Star Trek: Discovery#6#2017#2069#7"),
                new TvShow("6#The new Pope#1#2019#2020#8,1"),
                new TvShow("7#Space Force#2#2020#2022#6,7"),
                new TvShow("8#The young Pope#1#2016#2016#8,3"),
                new TvShow("9#Mr. Robot#7#2015#2019#8,6"),
                new TvShow("10#House of the Dragon#1#2022#2069#8,6"),
            });
            modelBuilder.Entity<Studio>().HasData(new Studio[]
            {
                new Studio("1#HBO"),
                new Studio("2#Netflix"),
                new Studio("3#Amazon"),
                new Studio("4#Apple"),
                new Studio("5#Disney"),
                new Studio("6#Paramount"),
                new Studio("7#Anonymus Content"),
            });
            modelBuilder.Entity<Actor>().HasData(new Actor[]
            {
                new Actor("1#Steve Carell"),
                new Actor("2#John Malkovich"),
                new Actor("3#Sonequa Martin-Green"),
                new Actor("4#Doug Jones"),
                new Actor("5#Jared Harris"),
                new Actor("6#Stellan Skarsgård"),
                new Actor("7#Kevin Spacey"),
                new Actor("8#Michel Gill"),
                new Actor("9#Rami Malek"),
                new Actor("10#Jude Law"),
                new Actor("11#Matt Smith"),
                new Actor("12#Millie Bobby Brown"),
            });
            modelBuilder.Entity<Role>().HasData(new Role[]
            {
                new Role("1#2#5#Valery Legasov"),
                new Role("2#2#6#Boris Shcherbina"),
                new Role("3#5#3#Michael Burnham"),
                new Role("4#5#4#Cmdr. Saru"),
                new Role("5#7#1#General Mark R. Naird"),
                new Role("6#7#2#Dr. Adrian Mallory"),
                new Role("7#6#2#Sir John Brannox"),
                new Role("8#6#10#Lenny Belardo"),
                new Role("9#9#9#Elliot Alderson"),
                new Role("10#9#8#Gideon Goddard"),
                new Role("11#2#11#Philip, Duke of Edinburgh"),
                new Role("12#10#11# Prince Daemon Targaryen"),
                new Role("13#4#7#Francis Underwood"),
                new Role("14#4#8#President Garett Walker"),
                new Role("15#3#12#Eleven"),
            });
        }
    }
}
