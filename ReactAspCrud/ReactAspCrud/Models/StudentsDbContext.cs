using Microsoft.EntityFrameworkCore;

namespace ReactAspCrud.Models
{
    public class StudentsDbContext : DbContext
    {
        public StudentsDbContext(DbContextOptions<StudentsDbContext> dbContextOptions) : base(dbContextOptions) 
        { 

        }

        public DbSet<Students> Students { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<ClassRoom> ClassRoom { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-QTRRLJQ\\SQLEXPRESS01;Initial Catalog=School; password=123 ;Integrated Security=True;TrustServerCertificate=True");
        }
    }

}
