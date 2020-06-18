using Microsoft.AspNetCore.Mvc;
using Qademli.Utility;

namespace Qademli.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Universities()
        {
            return View();
        }

        public IActionResult LearningCenter()
        {
            return View();
        }
        public IActionResult DetailPage()
        {
            return View();
        }

        public IActionResult IELTS()
        {
            return View();
        }
        public IActionResult TOEFL()
        {
            return View();
        }
        public IActionResult Visa()
        {
            return View();
        }

        public IActionResult AllGoal(string topic, int topicId)
        {
            ViewBag.Topic = topic;
            ViewBag.TopicID = topicId;
            return View();
        }
        public IActionResult Goal()
        {
            return View();
        }
        [CustomAuthorize(SD.User)]

        public IActionResult Application()
        {
            return View();
        }
    }
}