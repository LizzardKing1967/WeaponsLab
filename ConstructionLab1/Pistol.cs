using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace WeaponsLib
{
    public class Pistol : Firearm
    {

        private bool hasSafety;

        public Pistol(string weaponName, double weight, int fireRate, Caliber caliber, int ammoCapacity, bool hasSafety) : base(weaponName, weight, fireRate, caliber, ammoCapacity)
        {
            this.hasSafety = hasSafety;
        }

        public void ToggleSafety()
        {
            hasSafety = !hasSafety;
            Console.WriteLine("Safety " + (hasSafety ? "enabled" : "disabled"));
        }


        public override void Shoot(string target)
        {
            if (!hasSafety)
            {
                base.Shoot(target);
            }
            else
            {
                Console.WriteLine("Safety is enabled. Cannot shoot.");
            }
        }

        public override string ToString()
        {
            return base.ToString() + "Has Safety: " + hasSafety;
        }

    }

   
}
