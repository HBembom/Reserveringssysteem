using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ReservationSystemApi.Models;

namespace ReservationSystemApi.Controllers
{
    public class AccommodationsController : ApiController
    {
        Accommodations[] accommodationsTest = new Accommodations[]{
         new Accommodations { AccommodationId = 1, AccommodationType = "Test1" },
         new Accommodations { AccommodationId = 2, AccommodationType = "Test2" },
         new Accommodations { AccommodationId = 3, AccommodationType = "Test3" }
      };

        public IEnumerable<Accommodations> GetAllAccommodations()
        {
            return accommodationsTest;
        }

        public IHttpActionResult GetAccommodationById(int id)
        {
            var accommodation = accommodationsTest.FirstOrDefault((p) => p.AccommodationId == id);
            if (accommodation == null)
            {
                return NotFound();
            }
            return Ok(accommodation);
        }
    }
}
