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

        private string _weaponName;

        /// <summary>
        /// Поле, обозначающее степень опасности оружия
        /// </summary>
        private double _degreeOfDanger;


        /// <summary>
        /// Поле в котором хранится вес оружия
        /// </summary>


        private double _weight;


        /// <summary>
        /// Getter для поля parWeaponName
        /// </summary>
        public string WeaponName { get { return _weaponName; } }

        /// <summary>
        /// Getter для поля parDegreeOfDanger
        /// </summary>
        public double DegreeOfDanger {get { return _degreeOfDanger; } }

        /// <summary>
        /// Getter для поля parWeight
        /// </summary>
        public double Weight { get { return _weight; } }


        /// <summary>
        /// Конструктр базового класса Weapon
        /// </summary>
        /// <param name="parWeaponName"></param>
        /// <param name="parWeight"></param>
        /// <param name="parDegreeOfDanger"></param>

        public Weapon(string parWeaponName, double parWeight, double parDegreeOfDanger) 
        {
            Id = Guid.NewGuid();
            this._weaponName = parWeaponName;
            this._weight = parWeight;
            this._degreeOfDanger = parDegreeOfDanger;
        }
    
        /// <summary>
        /// Метод ToString, выводящий характеристики оружия
        /// </summary>
        /// <returns></returns>
        public override string ToString ()
        {
            return string.Format("Weapon id = {0}, Weapon name = {1}, Weapon parWeight = {2}, Weapon parWeight = {3}", Id, _weaponName, _weight, _degreeOfDanger);
        }

        /// <summary>
        /// Метод оценки урона от оружия
        /// </summary>
        /// <returns></returns>

        public virtual double GetDamage()
        {
            return _degreeOfDanger;
        }

    }

}
