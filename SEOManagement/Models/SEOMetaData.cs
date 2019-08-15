using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEOManagement.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<SEOMetaData> SEOMetaData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //format needed for Azure System Vars, stored in "Connection Strings"
            //optionsBuilder.UseSqlServer(System.Environment.GetEnvironmentVariable("SQLAZURECONNSTR_MyConnectionStringName"));

            optionsBuilder.UseSqlServer(System.Environment.GetEnvironmentVariable("stDevProductConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SEOMetaData>()
                .Property(b => b.Id)
                .ValueGeneratedOnAdd();

            #region SEOMetaDataSeed
            modelBuilder.Entity<SEOMetaData>().HasData(
                new SEOMetaData
                {
                    Id = 1,
                    Path = ".",
                    Title = "Default Title",
                    H1 = "Default H1",
                    Description = "Default Description"
                },
                new SEOMetaData
                {
                    Id = 2,
                    Path = "/",
                    Title = "Home Title",
                    H1 = "Home H1",
                    Description = "Home Description"
                },
                new SEOMetaData
                {
                    Id = 3,
                    Path = "/Home/About",
                    Title = "About Us Title",
                    H1 = "About Us H1",
                    Description = "About Us Description"
                },
                new SEOMetaData
                {
                    Id = 4,
                    Path = "/Home/SamplePage1",
                    Title = "SamplePage1 Title",
                    H1 = "SamplePage1 H1",
                    Description = "SamplePage1 Description"
                },
                new SEOMetaData
                {
                    Id = 5,
                    Path = "/Home/SamplePage2",
                    Title = "SamplePage2 Title",
                    H1 = "SamplePage2 H1",
                    Description = "SamplePage2 Description"
                },
                new SEOMetaData
                {
                    Id = 6,
                    Path = "/Home/Privacy",
                    Title = "Privacy Title",
                    H1 = "Privacy H1",
                    Description = "Privacy Description"
                }
            );
            #endregion
        }
    }

    public class SEOMetaData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
        public string H1 { get; set; }
        public string Description { get; set; }
    }
}
