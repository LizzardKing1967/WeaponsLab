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
        private bool _isEnchanted;

        /// <summary>
        /// Конструктр класса Sword
        /// </summary>
        /// <param name="parWeaponName"></param>
        /// <param name="parWeight"></param>
        /// <param name="parStrikeRate"></param>
        /// <param name="parDegreeOfSharpening"></param>
        /// <param name="parIsEnchanted"></param>
        public Sword(string parWeaponName, double parWeight, double parDegreeOfDanger, double parDegreeOfSharpening, double parStrikeRate, bool parIsEnchanted)
            : base(parWeaponName, parWeight, parDegreeOfDanger, parStrikeRate, parDegreeOfSharpening)
        {
            this._isEnchanted = parIsEnchanted;
        }
        /// <summary>
        /// Метод позволяющий зачаровать меч
        /// </summary>
        public void Enchant()
        {
            _isEnchanted = true;
        }
        /// <summary>
        /// Переопределенный метод ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}, Is Enchanted: {1}", base.ToString(), _isEnchanted);
        }
        /// <summary>
        /// Переопрделенный метод оценки урона, учитывающий зачарование меча
        /// </summary>
        /// <returns></returns>
        public override double GetDamage()
        {
            double newDamage = base.GetDamage();
            if (_isEnchanted) { 
                newDamage = newDamage * 1.2;
            }
            return newDamage;
        }
    }
}
