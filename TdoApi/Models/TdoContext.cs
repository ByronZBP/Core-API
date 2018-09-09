using Microsoft.EntityFrameworkCore;

namespace TdoApi.Models
{
    public class TdoContext : DbContext
    {
        public TdoContext(DbContextOptions<TdoContext> options) : base(options)
        { }
        public DbSet<TdoItem> TdoItems { get; set; }
    }
}