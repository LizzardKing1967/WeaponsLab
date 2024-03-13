using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionLab1
{
    internal class Rifle : Firearm
    {
        private int range;

        public Rifle(string weaponName, double weight, int fireRate, Caliber caliber, int ammoCapacity, int range)
            : base(weaponName, weight, fireRate, caliber, ammoCapacity)
        {
            this.range = range;
        }

        public void Zoom(int factor)
        {
            range *= factor;
            Console.WriteLine("Zoomed. New range: " + range + " meters");
        }

        public override string ToString()
        {
            return base.ToString() + "Range: " + range + " meters";
        }
    }
}
