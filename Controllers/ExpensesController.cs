using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TutorialWindowsMVC.Data;
using TutorialWindowsMVC.Data.Services;
using TutorialWindowsMVC.Models;

namespace TutorialWindowsMVC.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpensesService _expensesService;
        public ExpensesController(IExpensesService expensesService) 
        {

           _expensesService = expensesService;
            
        }
        //Asynch is beneficial as it allows for other tasks along the thread to be executed whilst the current thread is loading in the background
        public async Task<IActionResult> Index()
        {
            var expenses = await _expensesService.GetAll();
            return View(expenses);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Expense expense)
        {
            if(ModelState.IsValid)
            {
                //Expenses is the name of the dbset property
               await _expensesService.Add(expense);
                return RedirectToAction("Index");
            }
            return View(expense);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult GetChart()
        {
            var data = _expensesService.GetChartData();
            return Json(data);
        }
    }
}
