using Microsoft.EntityFrameworkCore;

namespace Proyecto_EMUS.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
    }
}
