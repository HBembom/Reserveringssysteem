using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReserveeringsSysteemApi.Controllers.Options;
using ReserveeringsSysteemApi.Models;
using ReserveeringsSysteemApi.Properties;

namespace ReserveeringsSysteemApi.Controllers
{
    [Route("api/[controller]")]
    public class ProfitsController : ControllerBase
    {
        public DbConnector Connector { get; }
        public ProfitsController(DbConnector connector)
        {
            Connector = connector;
        }

        [HttpGet("/api/profit_from_period")]
        public async Task<IActionResult> GetTotalProfitFromPeriod(string StartDate, string EndDate)
        {
            await Connector.Conn.OpenAsync();
            var model = new Profits(Connector);
            var res = await model.SelectTotalProfitFromPeriod(StartDate, EndDate);

            return res == null ? new NoContentResult() : new OkObjectResult(res);
        }

        [HttpGet("/api/total_profit")]
        public async Task<IActionResult> GetTotalProfit()
        {
            await Connector.Conn.OpenAsync();
            var model = new Profits(Connector);
            var res = await model.SelectTotalProfit();
            return res == null ? new NoContentResult() : new OkObjectResult(res);
        }  
        [HttpGet("/api/profit_by_period")]
        public async Task<IActionResult> GetTotalProfitByPeriod()
        {
            await Connector.Conn.OpenAsync();
            var model = new Profits(Connector);
            var res = await model.SelectTotalProfitByPeriod();
            return res == null ? new NoContentResult() : new OkObjectResult(res);
        }
    }
}
