using DrawingTable.Model.Entitites;
using Microsoft.EntityFrameworkCore;

namespace DrawingTable.Dal
{
    public class DrawingTableContext : DbContext
    {
        public DrawingTableContext(DbContextOptions<DrawingTableContext> options) : base(options)
        {
        }

        public DbSet<DemoItem> DemoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
