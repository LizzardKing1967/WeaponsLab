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

        private bool _hasSafety;

        /// <summary>
        /// Конструктор класса Pistol
        /// </summary>
        /// <param name="parWeaponName"></param>
        /// <param name="parWeight"></param>
        /// <param name="parDegreeOfDanger"></param>
        /// <param name="parFireRate"></param>
        /// <param name="parCaliber"></param>
        /// <param name="parAmmoCapacity"></param>
        /// <param name="parHasSafety"></param>

        public Pistol(string parWeaponName, double parWeight, double parDegreeOfDanger, int parFireRate, Caliber parCaliber, int parAmmoCapacity, bool parHasSafety) : base(parWeaponName, parWeight, parDegreeOfDanger,parFireRate, parCaliber, parAmmoCapacity)
        {
            this._hasSafety = parHasSafety;
        }

        /// <summary>
        /// Метод, переключающий предохранитель пистолета
        /// </summary>
        public void ToggleSafety()
        {
            _hasSafety = !_hasSafety;
        }

        /// <summary>
        /// Переопределенный метод стрельбы, проверяющий, стоит ли оружие на предохранителе
        /// </summary>
        /// <param name="parTarget"></param>
        public override string Shoot(string parTarget)
        {
            if (!_hasSafety)
            {
                return base.Shoot(parTarget);
            }
            else
            {
                return "Safety is enabled. Cannot shoot.";
            }
        }

        /// <summary>
        /// Переопределенный метод ToString
        /// </summary>
        /// <returns></returns>

        public override string ToString()
        {
            return string.Format("{0}, Has Safety: {1}", base.ToString(), _hasSafety);
        }

    }

   
}
