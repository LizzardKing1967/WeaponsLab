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

        private double _strikeRate;
       
        /// <summary>
        /// Поле ккласса, обозначающее степень заточки оружия
        /// </summary>

        private double _degreeOfSharpening;

        /// <summary>
        /// Getter для поля parDegreeOfSharpening
        /// </summary>

        public double DegreeOfSharpening { get { return this._degreeOfSharpening; } }

        /// <summary>
        /// Getter для поля parStrikeRate
        /// </summary>
        public double StrikeRate { get { return this._strikeRate; } }

        /// <summary>
        /// Конструктр для класса SteelArm
        /// </summary>
        /// <param name="parWeaponName"></param>
        /// <param name="parWeight"></param>
        /// <param name="parDegreeOfDanger"></param>
        /// <param name="parStrikeRate"></param>
        /// <param name="parDegreeOfSharpening"></param>
        public SteelArm(string parWeaponName, double parWeight, double parDegreeOfDanger, double parStrikeRate, double parDegreeOfSharpening) : base(parWeaponName, parWeight, parDegreeOfDanger)
        {
            this._strikeRate = parStrikeRate;
            this._degreeOfSharpening = parDegreeOfSharpening;

        }
       
        /// <summary>
        /// Метод удара холодным оружием по цели
        /// </summary>
        /// <param name="parTarget"></param>
        public virtual string Strike(String parTarget)
        {
            if (this._degreeOfSharpening > 0)
            {
                this._degreeOfSharpening--;
                return $"Strike to {parTarget}";
            }
            else
            {
                return "Your weapon is dull, sharp it!";
            }
        }

        /// <summary>
        /// Метод заточки холодного оружия
        /// </summary>
        public virtual void Sharpening()
        {
            this._degreeOfSharpening ++;
        }
        /// <summary>
        /// Переопределенный метод ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}, Strike rate: {1}, Degree of sharpening: {2}", base.ToString(), _strikeRate, _degreeOfSharpening);
        }

    }
}
