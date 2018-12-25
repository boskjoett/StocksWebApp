using System;
using System.Threading;
using Microsoft.AspNetCore.SignalR;
using StocksWebApp.Hubs;

namespace StocksWebApp.Models
{
    public class StockPriceSimulator : IStockPriceSimulator
    {
        private const int StockUpdateIntervalInMilliseconds = 1000;
        private Timer _priceTimer;
        private readonly IHubContext<StockPriceHub> _hubContext;
        private double _price;
        private Random _randomOffset;
        private Random _randomFactor;

        public StockPriceSimulator(IHubContext<StockPriceHub> hubContext)
        {
            _hubContext = hubContext;
            _randomOffset = new Random();
            _randomFactor = new Random();
        }

        public void Start()
        {
            _priceTimer = new Timer(OnTimerElapsed, this, StockUpdateIntervalInMilliseconds, StockUpdateIntervalInMilliseconds);
            _price = 60;
        }

        private void OnTimerElapsed(object state)
        {
            // Generate a new random price
            _price += ((_randomOffset.NextDouble() - 0.5) * _randomFactor.Next(5));
            _price = Math.Round(_price, 2);

            // Push to all clients via the SignalR hub
            _hubContext.Clients.All.SendAsync("PriceUpdated", "VWAG", _price);
        }
    }
}
