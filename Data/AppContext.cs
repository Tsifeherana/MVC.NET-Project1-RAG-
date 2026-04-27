using Microsoft.EntityFrameworkCore;
using Projet1.Models;
using System.Data.Common;

namespace Projet1.Data
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options ) :base(options)
        {}

        public DbSet<Student> Student {get; set;}
    }
}