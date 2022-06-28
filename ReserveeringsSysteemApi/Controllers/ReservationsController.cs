using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReserveeringsSysteemApi.Controllers.Options;
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

        [HttpGet("/api/get_reservation_by_accommodations")]
        public async Task<IActionResult> GetReservationByAccommodation(ReservationByAccommodationOptions body)
        {
            await Connector.Conn.OpenAsync();
            var model = new Reservations(Connector);
            var res = await model.SelectReservationByAccommodation(body);

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

        [HttpPut("{AccommodationId}")]
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
            res.PrefixName = body.PrefixName;
            res.LicensePlateName = body.LicensePlateName;
            res.ArrivalDate = body.ArrivalDate;
            res.StreetName = body.StreetName;
            res.DepartureDate = body.DepartureDate;
            res.AccommodationId = body.AccommodationId;
            res.AmountOfExtraAdults = body.AmountOfExtraAdults;
            res.AmountOfExtraPets = body.AmountOfExtraPets;
            res.TotalCost = body.TotalCost;
            res.PaymentStatus = body.PaymentStatus;
            await res.UpdateReservationId();

            return new OkObjectResult(res);
        }

        [HttpDelete("{AccommodationId}")]
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
