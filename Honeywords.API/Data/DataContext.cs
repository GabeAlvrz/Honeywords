using Microsoft.EntityFrameworkCore;
using Honeywords.API.Models;


namespace Honeywords.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Password> Passwords { get; set; }
        public DbSet<ExitSurvey> ExitSurveys { get; set; }
        public DbSet<GradSeniorSurvey> GradSeniorSurveys { get; set; }
        
    }
}