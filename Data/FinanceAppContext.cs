using Microsoft.EntityFrameworkCore;
using TutorialWindowsMVC.Models;

namespace TutorialWindowsMVC.Data
{
    public class FinanceAppContext: DbContext
    {
        public FinanceAppContext(DbContextOptions<FinanceAppContext> options):base(options)
        {
            
        }

       public DbSet<Expense> Expenses { get; set; }
    }
}
