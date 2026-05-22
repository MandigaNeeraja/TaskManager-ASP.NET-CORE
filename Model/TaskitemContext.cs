using Microsoft.EntityFrameworkCore;
namespace TaskManager.Model
{
    public class TaskitemContext: DbContext
    {
        public DbSet<Taskitem> Taskitems { get; set; }

        //public TaskitemContext(DbContextOptions<TaskitemContext> options) : base(options)

        public TaskitemContext(DbContextOptions options) : base(options)
        {
        }
    }
}
