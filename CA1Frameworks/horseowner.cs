using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1
{
    internal class HorseOwner : User
    {
        private List<Horse> ownedHorses;

        public HorseOwner(string userName, string role) : base(userName, role)
        {
            this.ownedHorses = new List<Horse>();
        }
    }
}