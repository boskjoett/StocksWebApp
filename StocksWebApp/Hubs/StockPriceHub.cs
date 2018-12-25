using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace StocksWebApp.Hubs
{
    public class StockPriceHub : Hub
    {
        public async Task SendStockPrice(string stockId, double price)
        {
            await Clients.All.SendAsync("StockPrice", stockId, price);
        }
    }
}
