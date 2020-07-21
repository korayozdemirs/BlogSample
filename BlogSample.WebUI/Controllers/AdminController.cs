using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogSample.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogSample.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICategoryService categoryService;
        public AdminController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryList()
        {
            return View(categoryService.getAll());
        }
    }
}