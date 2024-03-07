using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionLab1
{
    public class HandWeapon
    {
        public HandWeapon(string WeaponName, string Caliber, double Weight, int AmmoCapacity)
        {
            Id = Guid.NewGuid();
            this.AmmoCapacity = AmmoCapacity;
            this.CurrentCapacity = AmmoCapacity; 
            this.WeaponName = WeaponName;  
            this.Caliber = Caliber;
            this.Weight = Weight;

        }
        protected string WeaponName { get; set; }
        protected string Caliber { get; set; }

        protected double Weight { get; set; }

        protected int AmmoCapacity { get; set; }

        protected int CurrentCapacity { get; set; }

        protected Guid Id;

        protected void Shoot(String target)
        {
            if (this.CurrentCapacity > 0) { 
                Console.Write("Shoot to" + target);
                this.CurrentCapacity --;
            }
            else
            {
                Console.Write("No ammo");
            }
        }

        protected void Reload()
        { this.CurrentCapacity = AmmoCapacity; }

    }

}
