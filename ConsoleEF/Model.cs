using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ConsoleEF
{

    public class ModelContext : DbContext
    {
        public DbSet<Course> Courses {get; set;}
        public DbSet<Assignment> Assignments {get; set;}
        public DbSet<Module> Modules {get; set;}


        public String DbPath{get;}
        public ModelContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path =Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "canva.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

    }


    public class Course
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        public List<Module> Modules { get; set; }
        
    }

    public class Assignment
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public DateTime DueDate { get; set; }
    }

    public class Module
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<Assignment> Assignments { get; set; }
    }






}