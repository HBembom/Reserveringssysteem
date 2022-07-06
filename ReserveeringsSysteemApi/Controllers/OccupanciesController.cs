using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReserveeringsSysteemApi.Controllers.Options;
using ReserveeringsSysteemApi.Models;
using ReserveeringsSysteemApi.Properties;

namespace ReserveeringsSysteemApi.Controllers
{
    [Route("api/[controller]")]
    public class OccupanciesController : Controller
    {
        public DbConnector Connector { get; }
        public OccupanciesController(DbConnector connector)
        {
            Connector = connector;
        }

        [HttpPost]
        public async Task<IActionResult> PostOccupancy([FromBody] Occupancies body)
        {
            await Connector.Conn.OpenAsync();
            body.Connector = Connector;
            await body.InsertOccupancy();

            return new OkObjectResult(body);
        }

        [HttpGet("{OccupancyId}")]
        public async Task<IActionResult> GetOccupancyById(int OccupancyId)
        {
            await Connector.Conn.OpenAsync();
            var model = new Occupancies(Connector);
            var res = await model.SelectOccupancyById(OccupancyId);

            return res == null ? new NoContentResult() : new OkObjectResult(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOccupancies(OccupancyOptions options)
        {
            await Connector.Conn.OpenAsync();
            var model = new Occupancies(Connector);
            var res = await model.SelectAllOccupancies(options);
            return res == null ? new NoContentResult() : new OkObjectResult(res);
        }

        [HttpPut("{OccupancyId}")]
        public async Task<IActionResult> UpdateOccupancyById(int OccupancyId, [FromBody] Occupancies body)
        {
            await Connector.Conn.OpenAsync();
            var model = new Occupancies(Connector);
            var res = await model.SelectOccupancyById(OccupancyId);
            if (res == null)
            {
                return new NoContentResult();
            }
            res.AccommodationId = body.AccommodationId;
            res.ReservationId = body.ReservationId;
            res.ArrivalDate = body.ArrivalDate;
            res.DepartureDate = body.DepartureDate;
            res.PaymentStatus = body.PaymentStatus;
            await res.UpdateOccupancyById();

            return new OkObjectResult(res);
        }

        [HttpDelete("{OccupancyId}")]
        public async Task<IActionResult> DeleteOccupancyById(int OccupancyId)
        {
            await Connector.Conn.OpenAsync();
            var model = new Occupancies(Connector);
            var res = await model.SelectOccupancyById(OccupancyId);
            if (res == null)
            {
                return new NoContentResult();
            }
            await res.DeleteOccupancyById();

            return new OkResult();
        }
    }
}
