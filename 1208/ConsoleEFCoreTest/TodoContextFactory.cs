/** Class-1208: 練習 EF Core 的 Code First 開發流程 */
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFCore.Models
{
    public class TodoContextFactory : IDesignTimeDbContextFactory<TodoContext>
    {
        public TodoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TodoContext>();
            optionsBuilder.UseSqlServer("Server=AKA_LU_ASUS\\AKASERVER;Database=EFCoreTestDB;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new TodoContext(optionsBuilder.Options);
        }
    }
}