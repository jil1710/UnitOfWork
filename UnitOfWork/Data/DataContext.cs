using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UnitOfWork.Models;

namespace UnitOfWork.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
