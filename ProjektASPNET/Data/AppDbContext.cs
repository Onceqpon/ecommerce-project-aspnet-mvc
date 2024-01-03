using Microsoft.EntityFrameworkCore;

namespace ProjektASPNET.Data
{
    public class AppDbContext:DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
    }
}
