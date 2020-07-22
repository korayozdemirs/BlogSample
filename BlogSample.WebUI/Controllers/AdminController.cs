
using BlogSample.BLL.Abstract;
using BlogSample.DTO;
using BlogSample.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogSample.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        private readonly IArticleService articleService;
        public AdminController(ICategoryService _categoryService,
            IUserService _userService, IRoleService _roleService, IArticleService _articleService)
        {
            categoryService = _categoryService;
            userService = _userService;
            roleService = _roleService;
            articleService = _articleService;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region Article
        public IActionResult ArticleList()
        {
            ArticleViewModel model = new ArticleViewModel();
            model.ArticleDTOs = articleService.getAll();
            model.CategoryDTOs = categoryService.getAll();
            return View(model);
        }

        public IActionResult ArticleAdd()
        {
            ArticleViewModel viewModel = new ArticleViewModel();
            viewModel.CategoryDTOs = categoryService.getAll();
            return View(viewModel);
        }


        #endregion

        #region Role
        public IActionResult RoleList()
        {
            return View(roleService.getAll());
        }

        public IActionResult RoleAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RoleAdd(RoleDTO roleDTO)
        {
            roleService.newRole(roleDTO);
            return RedirectToAction("RoleList");
        }


        public IActionResult RoleDelete(int id)
        {
            roleService.deleteRole(id);
            return RedirectToAction("RoleList");
        }

        public IActionResult RoleEdit(int id)
        {
            RoleDTO selectedRole = roleService.getRole(id);
            return View(selectedRole);
        }

        [HttpPost]
        public IActionResult RoleEdit(RoleDTO roleDTO)
        {
            roleService.updateRole(roleDTO);
            return RedirectToAction("RoleList");
        }

        #endregion

        #region Category İşlemleri

        public IActionResult CategoryList()
        {
            return View(categoryService.getAll());
        }

        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(CategoryDTO categoryDTO)
        {
            categoryService.newCategory(categoryDTO);
            return RedirectToAction("CategoryList");
        }

        public IActionResult CategoryDelete(int id)
        {
            categoryService.deleteCategory(id);
            return RedirectToAction("CategoryList");
        }

        public IActionResult CategoryEdit(int id)
        {
            CategoryDTO selectedCategory = categoryService.getCategory(id);
            return View(selectedCategory);
        }

        [HttpPost]
        public IActionResult CategoryEdit(CategoryDTO categoryDTO)
        {
            categoryService.updateCategory(categoryDTO);
            return RedirectToAction("CategoryList");
        }
        #endregion

        #region User
        public IActionResult UserList()
        {
            return View(userService.getAll());
        }

        public IActionResult UserAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserAdd(UserDTO dto)
        {
            userService.newUser(dto);
            return RedirectToAction("UserList");
        }

        #endregion
    }
}