using crudProjectWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Education.Models
{
    public class DbContextApplication : DbContext
    {
        //add constructor
        public DbContextApplication(DbContextOptions<DbContextApplication> options)
            : base(options)
        {

        }
        // appel  model
        public DbSet<Register> Register { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<School> School { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<RegisterTeacher> RegisterTeachers { get; set; }
        public DbSet<RegisterInspector> RegisterInspectors { get; set; }
        public DbSet<RegisterDirector> RegisterDirectors { get; set; }
        public DbSet<Rank> Rank { get; set; }
        public DbSet<Formation> Formations { get; set; }



    }
}

