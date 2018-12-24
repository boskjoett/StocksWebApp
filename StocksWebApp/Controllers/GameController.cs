using Microsoft.AspNetCore.Mvc;

namespace StocksWebApp.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StartGame()
        {
            return View("Game");
        }
    }
}