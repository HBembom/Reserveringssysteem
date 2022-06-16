using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Fetches
{
    public abstract class Client
    {

       public abstract Task<object> GetById(int id);
       public abstract Task<object> GetAll();
    }
}
