using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReserveeringsSysteemApi.Models;
using ReserveeringsSysteemApi.Properties;

namespace ReserveeringsSysteemApi.Controllers
{
    [Route("api/[controller]")]
    public class PricesController : ControllerBase
    {
        public DbConnector Connector { get; }
        public PricesController(DbConnector connector)
        {
            Connector = connector;
        }

        [HttpPost]
        public async Task<IActionResult> PostPrice([FromBody] Prices body)
        {
            await Connector.Conn.OpenAsync();
            body.Connector = Connector;
            await body.InsertPrice();

            return new OkObjectResult(body);
        }

        [HttpGet("{Name}")]
        public async Task<IActionResult> GetPriceById(string Name)
        {
            await Connector.Conn.OpenAsync();
            var model = new Prices(Connector);
            var res = await model.SelectPriceById(Name);

            return res == null ? new NotFoundResult() : new OkObjectResult(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPrices()
        {
            await Connector.Conn.OpenAsync();
            var model = new Prices(Connector);
            var res = await model.SelectAllPrices();
            return res == null ? new NotFoundResult() : new OkObjectResult(res);
        }

        [HttpPut("{Name}")]
        public async Task<IActionResult> UpdatePriceById(string Name, [FromBody] Prices body)
        {
            await Connector.Conn.OpenAsync();
            var model = new Prices(Connector);
            var res = await model.SelectPriceById(Name);
            if (res == null)
            {
                return new NotFoundResult();
            }
            res.Amount = body.Amount;
            res.Name = body.Name;
            res.IsTax = body.IsTax;
            await res.UpdatePriceById();

            return new OkObjectResult(res);
        }

        [HttpDelete("{Name}")]
        public async Task<IActionResult> DeletePriceById(string Name)
        {
            await Connector.Conn.OpenAsync();
            var model = new Prices(Connector);
            var res = await model.SelectPriceById(Name);
            if (res == null)
            {
                return new NotFoundResult();
            }
            await res.DeletePriceById();

            return new OkResult();
        }
    }
}
