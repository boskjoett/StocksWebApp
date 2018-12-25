using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using StocksWebApp.Hubs;
using StocksWebApp.Models;

namespace StocksWebApp.Controllers
{
    public class GameController : Controller
    {
        private readonly IHubContext<StockPriceHub> _hubContext;
        private readonly IStockPriceSimulator _stockPriceSimulator;
        private readonly ILogger _logger;

        public GameController(IHubContext<StockPriceHub> hubContext,
                              IStockPriceSimulator stockPriceSimulator,
                              ILogger<GameController> logger)
        {
            _hubContext = hubContext;
            _stockPriceSimulator = stockPriceSimulator;
           _logger = logger;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StartGame()
        {
            // Start the game 
            _stockPriceSimulator.Start();

            // and show the game view page
            return View("Game");
        }
    }
}