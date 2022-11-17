using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleTools;
using JD0MUL_HFT_2022231.Client;
using JD0MUL_HFT_2022231.Models;

namespace JD0MUL_HFT_2022231
{
    internal class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            Console.Clear();
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
        static void List(string entity)
        {
            Console.Clear();
            Console.WriteLine("List option selected");
            if (entity== "TvShow")
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
            Console.WriteLine();
            Console.WriteLine("Hit enter to return to menu!");
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            Console.Clear();
            Console.WriteLine("Update option selected");
            if (entity == "TvShow")
            {
                var tvshow = new TvShow();
                Console.Write("Enter TvShow Id: ");
                tvshow.TvShowId = int.Parse(Console.ReadLine());
                Console.Write("Enter TvShow title: ");
                tvshow.Title = Console.ReadLine();
                rest.Put(tvshow, "tvshow");                
            }
            else if (entity == "Actor")
            {
                var actor = new Actor();
                Console.Write("Enter Actor Id: ");
                actor.ActorId = int.Parse(Console.ReadLine());
                Console.Write("Enter Actor name: ");
                actor.ActorName = Console.ReadLine();
                rest.Put(actor, "actor");
            }
            else if (entity == "Role")
            {
                var role = new Role();
                Console.Write("Enter Role Id: ");
                role.RoleId = int.Parse(Console.ReadLine());
                Console.Write("Enter Role name: ");
                role.RoleName = Console.ReadLine();
                rest.Put(role, "role");
            }
            else
            {
                var studio = new Studio();
                Console.Write("Enter Studio Id: ");
                studio.StudioId = int.Parse(Console.ReadLine());
                Console.Write("Enter Studio name: ");
                studio.StudioName = Console.ReadLine();
                rest.Put(studio, "studio");
            }
        }
        static void Delete(string entity)
        {
            Console.Clear();
            Console.WriteLine("Delete option selected");
            if (entity == "TvShow")
            {
                Console.Write("Enter TvShow Id: ");
                var id = int.Parse(Console.ReadLine());                
                rest.Delete(id, "tvshow");
            }
            else if (entity == "Actor")
            {
                Console.Write("Enter Actor Id: ");
                var id = int.Parse(Console.ReadLine());
                rest.Delete(id, "actor");
            }
            else if (entity == "Role")
            {
                Console.Write("Enter Role Id: ");
                var id = int.Parse(Console.ReadLine());
                rest.Delete(id, "role");
            }
            else
            {
                Console.Write("Enter Studio Id: ");
                var id = int.Parse(Console.ReadLine());
                rest.Delete(id, "studio");
            }
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:36235/","tvshow");

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

            var menu = new ConsoleMenu(args, level: 0)
                .Add("TvShows", () => showSubmenu.Show())
                .Add("Studios", () => studioSubmenu.Show())
                .Add("Actors", () => actorSubmenu.Show())
                .Add("Roles", () => roleSubmenu.Show())
                .Add("Exit", ConsoleMenu.Close);
            menu.Show();
        }
    }
}
