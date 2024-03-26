using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLib
{
    public class Sword : SteelArm
    {

        /// <summary>
        /// Поле класса, указывающие, зачарован ли меч
        /// </summary>
        private bool isEnchanted;


        /// <summary>
        /// Конструктр класса Sword
        /// </summary>
        /// <param name="weaponName"></param>
        /// <param name="weight"></param>
        /// <param name="strikeRate"></param>
        /// <param name="degreeOfSharpening"></param>
        /// <param name="isEnchanted"></param>
        public Sword(string weaponName, double weight, double strikeRate, double degreeOfSharpening, bool isEnchanted)
            : base(weaponName, weight, strikeRate, degreeOfSharpening)
        {
            this.isEnchanted = isEnchanted;
        }
        /// <summary>
        /// Метод позволяющий зачаровать меч
        /// </summary>
        public void Enchant()
        {
            isEnchanted = true;
            Console.WriteLine("Sword is enchanted!");
        }
        /// <summary>
        /// Переопределенный метод ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + "Is Enchanted: " + isEnchanted;
        }
        /// <summary>
        /// Переопрделенный метод оценки урона, учитывающий зачарование меча
        /// </summary>
        /// <param name="damage"></param>
        /// <returns></returns>
        public override double GetDamage(double damage)
        {
            double newDamage = base.GetDamage(damage);
            if (isEnchanted) { 
                newDamage = damage * 1.2;
            }
            return newDamage;
        }
    }
}
