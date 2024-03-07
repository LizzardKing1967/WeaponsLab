using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionLab1
{
    internal class Revolver : HandWeapon
    {
        public Revolver(string WeaponName, string Caliber, double Weight, int AmmoCapacity) : base(WeaponName, Caliber, Weight, AmmoCapacity)
        {
        }
    }
}
