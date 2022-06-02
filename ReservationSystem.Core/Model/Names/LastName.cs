using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Model.Names
{
    public class LastName : Name
    {
        public LastName(string name) : base(name)
        {
            MinimumLength = 1;
            MaximumLength = 20;
            AllowedCharacters = "[a - zA]";
        }
    }
}
