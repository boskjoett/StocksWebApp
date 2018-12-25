using System.Threading;
using Microsoft.AspNetCore.SignalR;
using StocksWebApp.Hubs;

namespace StocksWebApp.Models
{
    public class StockPriceSimulator : IStockPriceSimulator
    {
        private const int StockUpdateIntervalInMilliseconds = 2000;
        private Timer _priceTimer;
        private readonly IHubContext<StockPriceHub> _hubContext;
        private double _price;

        public StockPriceSimulator(IHubContext<StockPriceHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public void Start()
        {
            _priceTimer = new Timer(OnTimerElapsed, this, StockUpdateIntervalInMilliseconds, StockUpdateIntervalInMilliseconds);
            _price = 10;
        }

        private void OnTimerElapsed(object state)
        {
            // Push via SignalR
            _hubContext.Clients.All.SendAsync("PriceUpdated", "WVAG", _price);
            _price += 1;
        }
    }
}
