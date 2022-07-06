using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReserveeringsSysteemApi.Models;
using ReserveeringsSysteemApi.Properties;

namespace ReserveeringsSysteemApi.Controllers
{
    [Route("api/[controller]")]
    public class AccommodationsController : ControllerBase
    {
        public DbConnector Connector { get; }
        public AccommodationsController(DbConnector connector)
        {
            Connector = connector;
        }

        [HttpPost]
        public async Task<IActionResult> PostAccommodation([FromBody] Accommodations body)
        {
            await Connector.Conn.OpenAsync();
            body.Connector = Connector;
            await body.InsertAccommodation();

            return new OkObjectResult(body);
        }

        [HttpGet("{AccommodationId}")]
        public async Task<IActionResult> GetAccommodationById(int AccommodationId)
        {
            await Connector.Conn.OpenAsync();
            var model = new Accommodations(Connector);
            var res = await model.SelectAccommodationById(AccommodationId);

            return res == null ? new NoContentResult() : new OkObjectResult(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccommodations()
        {
            await Connector.Conn.OpenAsync();
            var model = new Accommodations(Connector);
            var res = await model.SelectAllAccommodations();
            return res == null ? new NoContentResult() : new OkObjectResult(res);
        }

        [HttpPut("{AccommodationId}")]
        public async Task<IActionResult> UpdateAccommodationById(int AccommodationId, [FromBody] Accommodations body)
        {
            await Connector.Conn.OpenAsync();
            var model = new Accommodations(Connector);
            var res = await model.SelectAccommodationById(AccommodationId);
            if (res == null)
            {
                return new NoContentResult();
            }
            res.AccommodationType = body.AccommodationType;
            await res.UpdateAccommodationById();

            return new OkObjectResult(res);
        }

        [HttpDelete("{AccommodationId}")]
        public async Task<IActionResult> DeleteAccommodationById(int AccommodationId)
        {
            await Connector.Conn.OpenAsync();
            var model = new Accommodations(Connector);
            var res = await model.SelectAccommodationById(AccommodationId);
            if (res == null)
            {
                return new NoContentResult();
            }
            await res.DeleteAccommodationById();

            return new OkResult();
        }
    }
}
