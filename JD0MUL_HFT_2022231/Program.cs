using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ConsoleTools;
using JD0MUL_HFT_2022231.Client;
using JD0MUL_HFT_2022231.Models;
using JD0MUL_HFT_2022231.Models.SideClasses;

namespace JD0MUL_HFT_2022231
{
    internal class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor= ConsoleColor.Yellow;
                Console.WriteLine("Create option selected");
                if (entity == "TvShow")
                {
                    Console.Write("Enter TvShow Name: ");
                    string name = Console.ReadLine();
                    rest.Post(new TvShow { Title = name }, "tvshow");
                }
                else if (entity == "Actor")
                {
                    Console.Write("Enter TvShow Name: ");
                    string name = Console.ReadLine();
                    rest.Post(new Actor { ActorName = name }, "actor");
                }
                else if (entity == "Role")
                {
                    Console.Write("Enter TvShow Name: ");
                    string name = Console.ReadLine();
                    rest.Post(new Role { RoleName = name }, "role");
                }
                else
                {
                    Console.Write("Enter TvShow Name: ");
                    string name = Console.ReadLine();
                    rest.Post(new Studio { StudioName = name }, "studio");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Hit enter to return to menu!");
                Console.ReadLine();
            }
            
        }
        static void List(string entity)
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("List option selected");
                Console.ForegroundColor = ConsoleColor.Green;
                if (entity == "TvShow")
                {
                    List<TvShow> tvshows = rest.Get<TvShow>("tvshow");
                    Console.WriteLine("Id" + "\t" + "Title");
                    foreach (var item in tvshows)
                    {                        
                        Console.WriteLine(item.TvShowId + "\t" + item.Title);
                    }
                }
                else if (entity == "Actor")
                {
                    List<Actor> actors = rest.Get<Actor>("actor");
                    Console.WriteLine("Id" + "\t" + "Name");
                    foreach (var item in actors)
                    {
                        Console.WriteLine(item.ActorId + "\t" + item.ActorName);
                    }
                }
                else if (entity == "Role")
                {
                    List<Role> roles = rest.Get<Role>("role");
                    Console.WriteLine("Id" + "\t" + "Name");
                    foreach (var item in roles)
                    {
                        Console.WriteLine(item.RoleId + "\t" + item.RoleName);
                    }
                }
                else
                {
                    List<Studio> studios = rest.Get<Studio>("studio");
                    Console.WriteLine("Id" + "\t" + "Name");
                    foreach (var item in studios)
                    {
                        Console.WriteLine(item.StudioId + "\t" + item.StudioName);
                    }
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Hit enter to return to menu!");
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Update option selected");
                if (entity == "TvShow")
                {
                    Console.Write("Enter tv show's Id to update: ");
                    var id = int.Parse(Console.ReadLine());
                    var tvshow = rest.Get<TvShow>(id, "tvshow");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[old name: {tvshow.Title}]");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Enter the new tv show title: ");
                    tvshow.Title = Console.ReadLine();
                    rest.Put(tvshow, "tvshow");
                }
                else if (entity == "Actor")
                {
                    Console.Write("Enter actor's Id to update: ");
                    var id = int.Parse(Console.ReadLine());
                    var actor = rest.Get<Actor>(id, "actor");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[old name: {actor.ActorName}]");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Enter the new actor name: ");
                    actor.ActorName = Console.ReadLine();
                    rest.Put(actor, "actor");
                }
                else if (entity == "Role")
                {
                    Console.Write("Enter role's Id to update: ");
                    var id = int.Parse(Console.ReadLine());
                    var role = rest.Get<Role>(id, "role");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[old name: {role.RoleName}]");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Enter the new role name: ");
                    role.RoleName = Console.ReadLine();
                    rest.Put(role, "role");
                }
                else
                {
                    Console.Write("Enter studio's Id to update: ");
                    var id = int.Parse(Console.ReadLine());
                    var studio = rest.Get<Studio>(id, "studio");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[old name: {studio.StudioName}]");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Enter the new studio name: ");
                    studio.StudioName = Console.ReadLine();
                    rest.Put(studio, "studio");
                }
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Hit enter to return to menu!");
                Console.ReadLine();
            }
        }
        static void Delete(string entity)
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Delete option selected");
                if (entity == "TvShow")
                {
                    Console.Write("Enter TvShow's Id to delete: ");
                    var id = int.Parse(Console.ReadLine());
                    rest.Delete(id, "tvshow");
                }
                else if (entity == "Actor")
                {
                    Console.Write("Enter Actor's Id to delete: ");
                    var id = int.Parse(Console.ReadLine());
                    rest.Delete(id, "actor");
                }
                else if (entity == "Role")
                {
                    Console.Write("Enter Role's Id to delete: ");
                    var id = int.Parse(Console.ReadLine());
                    rest.Delete(id, "role");
                }
                else
                {
                    Console.Write("Enter Studio's Id to delete: ");
                    var id = int.Parse(Console.ReadLine());
                    rest.Delete(id, "studio");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Hit enter to return to menu!");
            Console.ReadLine();
        }
        static void BestShowRoles()
        {
            try
            {
                List<Best> result = rest.Get<Best>("stat/besttvshowroles");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Best tv show's roles:");
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (var best in result)
                {
                    Console.Write($"{best.Title} show's roles: ");
                    foreach (var item in best.Roles)
                    {
                        Console.Write(item.RoleName + "," + " ");
                    }
                    Console.WriteLine();
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Hit enter to return to menu!");
            Console.ReadLine();
        }
        static void WorstShowActors()
        {
            List<Worst> result = rest.Get<Worst>("stat/worstshowactors");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Worst tv show's actors:");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var worst in result)
            {
                Console.Write($"{worst.Title} show's actors:");
                foreach (var item in worst.Actors)
                {
                    Console.Write(item.ActorName + "," + " ");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Hit enter to return to menu!");
            Console.ReadLine();
        }
        static void ActorBestTvShowRating()
        {
            try
            {
                List<ActorInfo> result = rest.Get<ActorInfo>("stat/actorbesttvshowrating");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Each actor's best show(s):");
                foreach (var item in result)
                {

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{item.ActorName}'s show(s): ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write($"({item.Rating}) ");
                    foreach (var title in item.Titles)
                    {
                        Console.Write(title + "," + " ");
                    }
                    Console.WriteLine();
                }
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Hit enter to return to menu!");
            Console.ReadLine();
        }
        static void ActorShowsAverage()
        {
            try
            {
                Console.Write("Enter actor id to show average show rating: ");
                var id = int.Parse(Console.ReadLine());
                var result = rest.Get<ActorRateInfo>(id, "stat/actorshowsaverage");
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine($"{result.ActorName} has {result.avgRating} average show rating");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);

            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Hit enter to return to menu!");
            Console.ReadLine();
        }
        static void LargestStudio()
        {
            try
            {
                var result = rest.Get<StudioInfo>("stat/largeststudio");
                foreach (var item in result)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{item.StudioName} is the largest studio, with {item.ShowNumber} shows, which are: ");
                    foreach (var title in item.TvShowTitles)
                    {
                        Console.Write("\t" + title + " ");
                    }
                    Console.WriteLine();
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Hit enter to return to menu!");
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:36235/","tvshow");

            Console.ForegroundColor = ConsoleColor.Cyan;
            var roleSubmenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Role"))
                .Add("Create", () => Create("Role"))
                .Add("Delete", () => Delete("Role"))
                .Add("Update", () => Update("Role"))
                .Add("Exit", ConsoleMenu.Close);

            var actorSubmenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Actor"))
                .Add("Create", () => Create("Actor"))
                .Add("Delete", () => Delete("Actor"))
                .Add("Update", () => Update("Actor"))
                .Add("Exit", ConsoleMenu.Close);

            var studioSubmenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Studio"))
                .Add("Create", () => Create("Studio"))
                .Add("Delete", () => Delete("Studio"))
                .Add("Update", () => Update("Studio"))
                .Add("Exit", ConsoleMenu.Close);

            var showSubmenu = new ConsoleMenu(args, level: 1)
                .Add("List", ()=>List("TvShow"))
                .Add("Create", () => Create("TvShow"))
                .Add("Delete", () => Delete("TvShow"))
                .Add("Update", () => Update("TvShow"))
                .Add("Exit", ConsoleMenu.Close);

            var statSubmenu = new ConsoleMenu(args, level: 1)
                .Add("Best show's roles", () => BestShowRoles())
                .Add("Worst show's actors", () => WorstShowActors())
                .Add("Each actor best show", () => ActorBestTvShowRating())
                .Add("Average show rating for selected actor", () => ActorShowsAverage())
                .Add("Largest Studio",()=> LargestStudio())
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("TvShows", () => showSubmenu.Show())
                .Add("Studios", () => studioSubmenu.Show())
                .Add("Actors", () => actorSubmenu.Show())
                .Add("Roles", () => roleSubmenu.Show())
                .Add("Statistics",()=>statSubmenu.Show())
                .Add("Exit", ConsoleMenu.Close);
            menu.Show();
        }
    }
}
