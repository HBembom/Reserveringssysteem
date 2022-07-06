using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReserveeringsSysteemApi.Models;
using ReserveeringsSysteemApi.Properties;

namespace ReserveeringsSysteemApi.Controllers
{
    [Route("api/[controller]")]

    public class GuestsController : ControllerBase
    {
        public DbConnector Connector { get; }
        public GuestsController(DbConnector connector)
        {
            Connector = connector;
        }

        [HttpPost]
        public async Task<IActionResult> PostGuest([FromBody] Guests body)
        {
            await Connector.Conn.OpenAsync();
            body.Connector = Connector;
            await body.InsertGuest();

            if (body.TypeOfGuest.Equals("Adult") || body.TypeOfGuest.Equals("Child") || body.TypeOfGuest.Equals("Pet"))
            {
                return new OkObjectResult(body);
            }

            return new StatusCodeResult(406);
        }

        [HttpGet("{GuestId}")]
        public async Task<IActionResult> GetGuestById(int GuestId)
        {
            await Connector.Conn.OpenAsync();
            var model = new Guests(Connector);
            var res = await model.SelectGuestById(GuestId);

            return res == null ? new NoContentResult() : new OkObjectResult(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGuests()
        {
            await Connector.Conn.OpenAsync();
            var model = new Guests(Connector);
            var res = await model.SelectAllGuests();
            return res == null ? new NoContentResult() : new OkObjectResult(res);
        }

        [HttpPut("{GuestId}")]
        public async Task<IActionResult> UpdateGuestById(int GuestId, [FromBody] Guests body)
        {
            await Connector.Conn.OpenAsync();
            var model = new Guests(Connector);
            var res = await model.SelectGuestById(GuestId);
            if (res == null)
            {
                return new NoContentResult();
            }
            res.AmountOfDays = body.AmountOfDays;
            res.TypeOfGuest = body.TypeOfGuest;
            res.Price = body.Price;
            await res.UpdateGuestById();

            if (body.TypeOfGuest.Equals("Adult") || body.TypeOfGuest.Equals("Child") || body.TypeOfGuest.Equals("Pet"))
            {
                return new OkObjectResult(res);
            }

            return new StatusCodeResult(406);
        }

        [HttpDelete("{GuestId}")]
        public async Task<IActionResult> DeleteGuestById(int GuestId)
        {
            await Connector.Conn.OpenAsync();
            var model = new Guests(Connector);
            var res = await model.SelectGuestById(GuestId);
            if (res == null)
            {
                return new NoContentResult();
            }
            await res.DeleteGuestById();

            return new OkResult();
        }
    }
}
