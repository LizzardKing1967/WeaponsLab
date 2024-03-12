using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionLab1
{
    internal class Firearm : Weapon
    {
        public Firearm(string weaponName, double weight, int fireRate, Caliber caliber, int ammoCapacity) : base(weaponName, weight)
        {
            this.fireRate = fireRate;
            this.ammoCapacity = ammoCapacity;
            this.currentCapacity = ammoCapacity;
            this.caliber = caliber;
        }

        protected int fireRate { get; set; }

        protected int ammoCapacity { get; set; }

        protected int currentCapacity { get; set; }

        private Caliber caliber;

        protected virtual void Shoot(String target)
        {
            if (this.currentCapacity > 0)
            {
                Console.Write("Shoot to" + target);
                this.currentCapacity--;
            }
            else
            {
                Console.Write("No ammo");
            }
        }

        protected void Reload()
        { this.currentCapacity = ammoCapacity; }

        protected override double getDamage(double damage)
        {
            return fireRate * caliber.CaliberDamage;
        }

        public override string ToString()
        {
            return base.ToString() + "Caliber " + caliber + "Fire Rate " + fireRate + "Ammo capacity "
                + ammoCapacity + "Current capacity " + currentCapacity;
        }
    }
}
