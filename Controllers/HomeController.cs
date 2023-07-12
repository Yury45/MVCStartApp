﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCStartApp.Models;
using MVCStartApp.Models.Db;
using MVCStartApp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStartApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogRepository _blogRepository;

        public HomeController(ILogger<HomeController> logger, IBlogRepository blogRepository)
        {
            _logger = logger;
            _blogRepository = blogRepository;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var newUser = new User()
            {
                Id = Guid.NewGuid(),
                Firstname = "Andrey",
                Lastname = "Petrov",
                CreatedDate = DateTime.Now
            };

            // Добавим в базу
            await _blogRepository.AddUser(newUser);

            // Выведем результат
            Console.WriteLine($"User with id {newUser.Id}, named {newUser.Firstname} was successfully added on {newUser.CreatedDate}");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> Authors()
        {
            var authors = await _blogRepository.GetUsers();

            Console.WriteLine("See all blog authors:");
            foreach (var author in authors)
                Console.WriteLine($"Author name {author.Firstname}, joined {author.CreatedDate}");

            return View();
        }
    }
}
