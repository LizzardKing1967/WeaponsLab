using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLib
{
    public class Firearm : Weapon
    {

        /// <summary>
        /// Поле класса, обозначающий темп стрельбы оружия
        /// </summary>
        private int fireRate;

        /// <summary>
        /// Getter для поля fireRate
        /// </summary>
        public int FireRate { get { return this.fireRate; } }


        /// <summary>
        /// Поле, обозначающие емкость магазина оружия
        /// </summary>
        private int ammoCapacity;

    
        /// <summary>
        /// Поле обозначающее текущее количество боеприпасов в оружии
        /// </summary>

        private int currentCapacity { get; set; }

        

        /// <summary>
        /// Getter для поля ammoCapacity
        /// </summary>


        public int AmmoCapacity { get { return this.ammoCapacity; } }

        /// <summary>
        /// Getter для поля currentCapacity
        /// </summary>

        public int CurentCapacity { get { return this.currentCapacity; } }

        /// <summary>
        /// Поле класса Caliber, обозначающее калибр оружия
        /// </summary>
        private Caliber caliber;

        /// <summary>
        /// Конструктр для класса FireArm
        /// </summary>
        /// <param name="weaponName"></param>
        /// <param name="weight"></param>
        /// <param name="fireRate"></param>
        /// <param name="caliber"></param>
        /// <param name="ammoCapacity"></param>

        public Firearm(string weaponName, double weight, int fireRate, Caliber caliber, int ammoCapacity) : base(weaponName, weight)
        {
            this.fireRate = fireRate;
            this.ammoCapacity = ammoCapacity;
            this.currentCapacity = ammoCapacity;
            this.caliber = caliber;
        }


        /// <summary>
        /// Метод выполения выстрела из оружия
        /// </summary>
        /// <param name="target"></param>

       
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

        /// <summary>
        /// Метод перезарядки оружия
        /// </summary>

        public void Reload()
        { 
            this.currentCapacity = ammoCapacity; 
        }

        /// <summary>
        /// Переопределенный метод оценки урона, учитывающий темп стрельбы и калибр оружия
        /// </summary>
        /// <param name="damage"></param>
        /// <returns></returns>
        public override double GetDamage(double damage)
        {
            return fireRate * caliber.CaliberDamage;
        }


        /// <summary>
        /// Переопределенный метод ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + "Caliber " + caliber + "Fire Rate " + fireRate + "Ammo capacity "
                + ammoCapacity + "Current capacity " + currentCapacity;
        }
    }
}
