using TutorialWindowsMVC.Models;
namespace TutorialWindowsMVC.Data.Services
{
    public interface IExpensesService
    {
        Task<IEnumerable<Expense>> GetAll();
        Task Add(Expense expense);
        IQueryable GetChartData();


    }
}
