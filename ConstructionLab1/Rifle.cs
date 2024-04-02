using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLib
{
    /// <summary>
    /// Класс Rifle, наследник класса Firearm
    /// </summary>
    public class Rifle : Firearm
    {

        /// <summary>
        /// Дистанция стрельбы из винтовки
        /// </summary>
        private int _range;

        /// <summary>
        /// Getter и Setter для поля _range
        /// </summary>
        public int Range { 
            get { return _range; } 
            set { _range = value; }
        }

        /// <summary>
        /// Конструктр класса Rifle
        /// </summary>
        /// <param name="parWeaponName"></param>
        /// <param name="parWeight"></param>
        /// <param name="parDegreeOfDanger"></param>
        /// <param name="parFireRate"></param>
        /// <param name="parCaliber"></param>
        /// <param name="parAmmoCapacity"></param>
        /// <param name="parRange"></param>
        public Rifle(string parWeaponName, double parWeight, double parDegreeOfDanger, int parFireRate, Caliber parCaliber, int parAmmoCapacity, int parRange)
            : base(parWeaponName, parWeight, parDegreeOfDanger, parFireRate, parCaliber, parAmmoCapacity)
        {
            this._range = parRange;
        }
        /// <summary>
        /// Метод для прицеливания из винтовки, увеличивающий дистанции выстрела
        /// </summary>
        /// <param name="parFactor">Дистанция пристрелки</param>
        public void Zoom(int parFactor)
        {
            _range *= parFactor;
        }
        /// <summary>
        /// Переопределенный метод ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}, Range: {1} meters", base.ToString(), _range);
        }
    }
}
