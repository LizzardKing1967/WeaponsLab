using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLib
{
    public class SteelArm : Weapon
    {

        /// <summary>
        /// Поле класса, обозначающий скорость удара холодным оружием
        /// </summary>

        private double strikeRate;

        /// <summary>
        /// Getter для поля strikeRate
        /// </summary>
        public double StrikeRate { get { return this.strikeRate; } }

        /// <summary>
        /// Поле ккласса, обозначающее степень заточки оружия
        /// </summary>

        private double degreeOfSharpening;

        /// <summary>
        /// Getter для поля degreeOfSharpening
        /// </summary>

        public double DegreeOfSharpening { get { return this.degreeOfSharpening; } }
       
        /// <summary>
        /// Конструктр для класса SteelArm
        /// </summary>
        /// <param name="weaponName"></param>
        /// <param name="weight"></param>
        /// <param name="strikeRate"></param>
        /// <param name="degreeOfSharpening"></param>
        public SteelArm(string weaponName, double weight, double strikeRate, double degreeOfSharpening) : base(weaponName, weight)
        {
            this.strikeRate = strikeRate;
            this.degreeOfSharpening = degreeOfSharpening;

        }
       
        /// <summary>
        /// Метод удара холодным оружием по цели
        /// </summary>
        /// <param name="target"></param>
        public virtual void Strike(String target)
        {
            if (this.degreeOfSharpening > 0)
            {
                Console.Write("Strike to" + target);
                this.degreeOfSharpening--;
            }
            else
            {
                Console.Write("Your weapon is dull, sharp it!");
            }
        }

        /// <summary>
        /// Метод заточки холодного оружия
        /// </summary>
        public virtual void Sharpening()
        {
            this.degreeOfSharpening ++;
        }
        /// <summary>
        /// Переопределенный метод ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + "Strike rate" + strikeRate + "Degree of sharpening" + degreeOfSharpening;
        }




    }
}
