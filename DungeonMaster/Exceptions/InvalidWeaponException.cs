using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMaster.Exceptions
{
    internal class InvalidWeaponException : Exception
    {
        public InvalidWeaponException(string message) : base(message) { }
    }
}
