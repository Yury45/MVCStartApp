using Microsoft.AspNetCore.Mvc;
using MVCStartApp.Models;
using MVCStartApp.Models.Db;
using MVCStartApp.Repository.Interfaces;
using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MVCStartApp.Controllers
{
    public class FeedbackController : Controller
    {
        public IFeedbackRepository _feedbackRepository { get; set; }

        public FeedbackController(IFeedbackRepository feedbackRepository)
        { 
            _feedbackRepository = feedbackRepository;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Feedback feedback)
        {
            await _feedbackRepository.Add(feedback);
            return StatusCode(200, $"{feedback.From}, благодарим за отзыв!");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var feedbacks = await _feedbackRepository.GetFeedbacks();
            return View(feedbacks);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
