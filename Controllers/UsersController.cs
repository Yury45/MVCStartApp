using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCStartApp.Models.Db;
using MVCStartApp.Repository.Interfaces;
using System.Threading.Tasks;

namespace MVCStartApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IBlogRepository _blogRepository;

        public UsersController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<ActionResult> Index()
        {
            var authors = await _blogRepository.GetUsers();
            return View(authors);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User newUser)
        {
            await _blogRepository.AddUser(newUser);
            return View(newUser);
        }
    }
}