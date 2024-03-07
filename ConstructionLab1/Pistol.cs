using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ConstructionLab1
{
    internal class Pistol : HandWeapon
    {
        public Pistol(string WeaponName, string Caliber, double Weight, int AmmoCapacity) : base(WeaponName, Caliber, Weight, AmmoCapacity)
        {
            CurrentCapacity = AmmoCapacity;
        }
    }
}
