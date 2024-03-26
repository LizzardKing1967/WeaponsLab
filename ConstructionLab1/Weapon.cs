using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLib
{
    public class Weapon
    {
        /// <summary>
        /// Поле - идентификатор класса
        /// </summary>
        private Guid Id;

        /// <summary>
        /// Поле наименование оружия
        /// </summary>

        private string weaponName;

        public string WeaponName { get { return weaponName; } }

        /// <summary>
        /// Поле в котором хранится вес оружия
        /// </summary>

        
        private double weight;

        public double Weight { get { return weight; } }

        /// <summary>
        /// Поле обозначающее урон от оружия
        /// </summary>

        private double damage;

        /// <summary>
        /// Конструктр базового класса Weapon
        /// </summary>
        /// <param name="weaponName"></param>
        /// <param name="weight"></param>

        public Weapon(string weaponName, double weight) 
        {
            Id = Guid.NewGuid();
            this.weaponName = weaponName;
            this.weight = weight;
        }
    
        /// <summary>
        /// Метод ToString, выводящий характеристики оружия
        /// </summary>
        /// <returns></returns>
        public override string ToString ()
        {
            return "Weapon id = " + Id + "Weapon name = " + weaponName + "Weapon weight = " + weight;
        }

        /// <summary>
        /// Метод оценки урона от оружия
        /// </summary>
        /// <param name="damage"></param>
        /// <returns></returns>

        public virtual double GetDamage(double damage)
        {
            return damage;
        }

    }

}
