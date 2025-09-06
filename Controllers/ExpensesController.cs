using Microsoft.AspNetCore.Mvc;
using TutorialWindowsMVC.Data;

namespace TutorialWindowsMVC.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly FinanceAppContext _context;
        public ExpensesController(FinanceAppContext context) 
        {

            _context = context;
            
        }
        public IActionResult Index()
        {
            var expenses = _context.Expenses.ToList();
            return View(expenses);
        }

        public IActionResult Create()
        {
            return View();


        }
    }
}
