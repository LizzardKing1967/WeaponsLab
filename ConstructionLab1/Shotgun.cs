using System;

namespace ConstructionLab1
{
    internal class Shotgun : HandWeapon
    {
        public Shotgun(string WeaponName, string Caliber, double Weight, int AmmoCapacity) : base(WeaponName, Caliber, Weight, AmmoCapacity)
        {
        }
    }
}
