using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class Context : DbContext
    {
        private string cadenaConexion;

        public DbSet<Character> Characters { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<User> Users { get; set; }

        public Context(DbContextOptions options) : base(options)
        {



        }

        public Context() : base()
        {
            var configuration = GetConfiguration();
            cadenaConexion = configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;

        }

        public IConfigurationRoot GetConfiguration()
        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(cadenaConexion);
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))

            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(builder);

        }

    }
}