using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLib
{
    public class Rifle : Firearm
    {
        /// <summary>
        /// Поле класса, обозначающее дистанции стрельбы из винтовки
        /// </summary>

        private int range;

        /// <summary>
        /// Конструктр класса Rifle
        /// </summary>
        /// <param name="weaponName"></param>
        /// <param name="weight"></param>
        /// <param name="fireRate"></param>
        /// <param name="caliber"></param>
        /// <param name="ammoCapacity"></param>
        /// <param name="range"></param>

        public Rifle(string weaponName, double weight, int fireRate, Caliber caliber, int ammoCapacity, int range)
            : base(weaponName, weight, fireRate, caliber, ammoCapacity)
        {
            this.range = range;
        }
        /// <summary>
        /// Метод для прицеливания из винтовки, увеличивающий дистанции выстрела
        /// </summary>
        /// <param name="factor"></param>
        public void Zoom(int factor)
        {
            range *= factor;
            Console.WriteLine("Zoomed. New range: " + range + " meters");
        }
        /// <summary>
        /// Переопределенный метод ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + "Range: " + range + " meters";
        }
    }
}
