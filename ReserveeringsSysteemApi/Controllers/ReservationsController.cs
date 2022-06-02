using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReserveeringsSysteemApi.Models;
using ReserveeringsSysteemApi.Properties;

namespace ReserveeringsSysteemApi.Controllers
{
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        public DbConnector Connector { get; }
        public ReservationsController(DbConnector connector)
        {
            Connector = connector;
        }

        [HttpPost]
        public async Task<IActionResult> PostReservation([FromBody] Reservations body)
        {
            await Connector.Conn.OpenAsync();
            body.Connector = Connector;
            await body.InsertReservation();

            return new OkObjectResult(body);
        }

        [HttpGet("{ReservationId}")]
        public async Task<IActionResult> GetReservationById(int ReservationId)
        {
            await Connector.Conn.OpenAsync();
            var model = new Reservations(Connector);
            var res = await model.SelectReservationById(ReservationId);

            return res == null ? new NotFoundResult() : new OkObjectResult(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            await Connector.Conn.OpenAsync();
            var model = new Reservations(Connector);
            var res = await model.SelectAllReservations();
            return res == null ? new NotFoundResult() : new OkObjectResult(res);
        }

        [HttpPut("{ReservationId}")]
        public async Task<IActionResult> UpdateReservationById(int ReservationId, [FromBody] Reservations body)
        {
            await Connector.Conn.OpenAsync();
            var model = new Reservations(Connector);
            var res = await model.SelectReservationById(ReservationId);
            if (res == null)
            {
                return new NotFoundResult();
            }
            res.FirstName = body.FirstName;
            res.LastName = body.LastName;
            res.Address = body.Address;
            res.Email = body.Email;
            res.Phone = body.Phone;
            res.ArrivalDate = body.ArrivalDate;
            res.DepartureDate = body.DepartureDate;
            res.AccommodationId = body.AccommodationId;
            res.AmountOfExtraAdults = body.AmountOfExtraAdults;
            res.AmountOfExtraPets = body.AmountOfExtraPets;
            res.TotalCost = body.TotalCost;
            await res.UpdateReservationId();

            return new OkObjectResult(res);
        }

        [HttpDelete("{ReservationId}")]
        public async Task<IActionResult> DeleteReservationById(int ReservationId)
        {
            await Connector.Conn.OpenAsync();
            var model = new Reservations(Connector);
            var res = await model.SelectReservationById(ReservationId);
            if (res == null)
            {
                return new NotFoundResult();
            }
            await res.DeleteReservationById();

            return new OkResult();
        }
    }
}
