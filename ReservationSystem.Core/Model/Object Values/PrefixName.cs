using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Core.Model.Names
{
    public class PrefixName : Name
    {
        public PrefixName(string name) : base(name)
        {
            MinimumLength = 0;
            MaximumLength = 10;
            AllowedCharacters = "[a - zA]";
        }
    }
}
