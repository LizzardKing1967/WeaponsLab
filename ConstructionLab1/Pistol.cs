using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ConstructionLab1
{
    internal class Pistol : Firearm
    {
        
        private bool isHolstered;

        public Pistol(string weaponName, double weight, int fireRate, string caliber, int ammoCapacity) : base(weaponName, weight, fireRate, caliber, ammoCapacity)
        {
            isHolstered = true;
        }


        //метод вытаскивания или убирания пистолта в кобуру
        public void Holster()
        {
            if (isHolstered)
            {
                Console.WriteLine($"{weaponName} is already holstered.");
            }
            else
            {
                Console.WriteLine($"Holstering {weaponName}");
                isHolstered = true;
            }
        }

        protected override void Shoot(string target)
        {
            if (isHolstered)
            {
                Console.WriteLine($"Draw {weaponName} before shooting.");
            }
            else
            {
                base.Shoot(target);
            }
        }
    }

   
}
