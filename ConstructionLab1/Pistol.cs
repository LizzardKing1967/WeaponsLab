using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace WeaponsLib
{
    /// <summary>
    /// Класс Pistol, наследник класса Firearm
    /// </summary>
    public class Pistol : Firearm
    {
        /// <summary>
        /// Нахождение оружия на предохранителе
        /// </summary>
        private bool _hasSafety;

        /// <summary>
        /// Getter и Setter для поля _hasSafety
        /// </summary>
        public bool HasSafety {  
            get { return _hasSafety; }
            set { _hasSafety = value; }
        }

        /// <summary>
        /// Конструктор класса Pistol
        /// </summary>
        /// <param name="parWeaponName">Название пистолета</param>
        /// <param name="parWeight">Вес пистолета</param>
        /// <param name="parDegreeOfDanger">Степень опасности пистолета</param>
        /// <param name="parFireRate">Скорострельность</param>
        /// <param name="parCaliber">Калибр пистолета</param>
        /// <param name="parAmmoCapacity">Емкость магазина</param>
        /// <param name="parHasSafety">Наличие предохранителя</param>
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
        /// <param name="parTarget">Цель для выстрела</param>
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
