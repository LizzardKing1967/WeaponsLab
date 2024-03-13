using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLib
{
    public class Firearm : Weapon
    {
        public Firearm(string weaponName, double weight, int fireRate, Caliber caliber, int ammoCapacity) : base(weaponName, weight)
        {
            this.fireRate = fireRate;
            this.ammoCapacity = ammoCapacity;
            this.currentCapacity = ammoCapacity;
            this.caliber = caliber;
        }

        protected int fireRate;
        public int FireRate { get { return this.fireRate; } }

        protected int ammoCapacity;

        public int AmmoCapacity { get { return this.ammoCapacity; } }
        protected int currentCapacity { get; set; }

        public int CurentCapacity { get { return this.currentCapacity; } }

        private Caliber caliber;

        public virtual void Shoot(String target)
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

        public void Reload()
        { this.currentCapacity = ammoCapacity; }

        public override double GetDamage(double damage)
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
