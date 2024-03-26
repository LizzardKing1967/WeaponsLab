using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLib
{
    public class Axe : SteelArm
    {
        /// <summary>
        /// Поле для класса, обозначающее длину рукоятки топора
        /// </summary>

        private int handleLength;

        /// <summary>
        /// Конструктор класса Axe
        /// </summary>
        /// <param name="weaponName"></param>
        /// <param name="weight"></param>
        /// <param name="strikeRate"></param>
        /// <param name="degreeOfSharpening"></param>
        /// <param name="handleLength"></param>
        public Axe(string weaponName, double weight, double strikeRate, double degreeOfSharpening, int handleLength)
            : base(weaponName, weight, strikeRate, degreeOfSharpening)
        {
            this.handleLength = handleLength;
        }

        /// <summary>
        /// Метод класса, отвечающий за расширение рукоятки топора
        /// </summary>
        /// <param name="length"></param>

        public void ExtendHandle(int length)
        {
            this.handleLength += length;
            Console.WriteLine("Handle extended by " + length + " cm.");
        }

        /// <summary>
        /// Переопределенный метод ToString
        /// </summary>
        /// <returns></returns>

        public override string ToString()
        {
            return base.ToString() + "Handle Length: " + handleLength + " cm";
        }

        /// <summary>
        /// Переопределенный метод оценки урона от оружия, учитывающий длину рукоятки топора
        /// </summary>
        /// <param name="damage"></param>
        /// <returns></returns>

        public override double GetDamage(double damage)
        {
            return base.GetDamage(damage) * (this.handleLength/100);
        }
    }
}
