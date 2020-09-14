namespace admTarea1.Models
{
    using System.Data.Entity;
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<admTarea1.Models.jimenez> jimenezs { get; set; }
    }
}