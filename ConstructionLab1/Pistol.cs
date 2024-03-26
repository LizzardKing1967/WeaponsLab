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
        /// <summary>
        /// Свойства класса, обозначающее находится ли оружие на предохранителе
        /// </summary>

        private bool hasSafety;

        /// <summary>
        /// Конструктор класса Pistol
        /// </summary>
        /// <param name="weaponName"></param>
        /// <param name="weight"></param>
        /// <param name="fireRate"></param>
        /// <param name="caliber"></param>
        /// <param name="ammoCapacity"></param>
        /// <param name="hasSafety"></param>

        public Pistol(string weaponName, double weight, int fireRate, Caliber caliber, int ammoCapacity, bool hasSafety) : base(weaponName, weight, fireRate, caliber, ammoCapacity)
        {
            this.hasSafety = hasSafety;
        }

        /// <summary>
        /// Метод, переключающий предохранитель пистолета
        /// </summary>
        public void ToggleSafety()
        {
            hasSafety = !hasSafety;
            Console.WriteLine("Safety " + (hasSafety ? "enabled" : "disabled"));
        }

        /// <summary>
        /// Переопределенный метод стрельбы, проверяющий, стоит ли оружие на предохранителе
        /// </summary>
        /// <param name="target"></param>
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

        /// <summary>
        /// Переопределенный метод ToString
        /// </summary>
        /// <returns></returns>

        public override string ToString()
        {
            return base.ToString() + "Has Safety: " + hasSafety;
        }

    }

   
}
