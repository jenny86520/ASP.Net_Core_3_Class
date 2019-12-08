/** Class-1208: 練習 EF Core 的 Code First 開發流程 */
using Microsoft.EntityFrameworkCore;

namespace EFCore.Models {
    public class TodoContext : DbContext {
        public TodoContext (DbContextOptions<TodoContext> options) : base (options) { }
        public DbSet<Todo> Todos { get; set; }
    }
}