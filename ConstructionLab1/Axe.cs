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

        private int _handleLength;

        /// <summary>
        /// Конструктор класса Axe
        /// </summary>
        /// <param name="parWeaponName"></param>
        /// <param name="parWeight"></param>
        /// <param name="parStrikeRate"></param>
        /// <param name="parDegreeOfSharpening"></param>
        /// <param name="parHandleLength"></param>
        /// <param name="parDegreeOfDanger"></param>
        public Axe(string parWeaponName, double parWeight, double parDegreeOfDanger, double parStrikeRate, double parDegreeOfSharpening, int parHandleLength)
            : base(parWeaponName, parWeight, parDegreeOfDanger ,parStrikeRate, parDegreeOfSharpening)
        {
            this._handleLength = parHandleLength;
        }

        /// <summary>
        /// Метод класса, отвечающий за расширение рукоятки топора
        /// </summary>
        /// <param name="parLength"></param>

        public void ExtendHandle(int parLength)
        {
            this._handleLength += parLength;
        }

        /// <summary>
        /// Переопределенный метод ToString
        /// </summary>
        /// <returns></returns>

        public override string ToString()
        {
            return string.Format("{0}, Handle Length: {1} cm", base.ToString(), _handleLength);
        }


        /// <summary>
        /// Переопределенный метод оценки урона от оружия, учитывающий длину рукоятки топора
        /// </summary>
        /// <returns></returns>
        public override double GetDamage()
        {
            return base.GetDamage() * (this._handleLength/100);
        }
    }
}
