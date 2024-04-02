using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLib
{

    /// <summary>
    /// Базовый класс для ручного оружия
    /// </summary>
    public class Weapon
    {
        /// <summary>
        /// Идентификатор класса
        /// </summary>
        private Guid _Id;

        /// <summary>
        /// Наименование оружия
        /// </summary>
        private string _weaponName;

        /// <summary>
        /// Степень опасности оружия
        /// </summary>
        private double _degreeOfDanger;

        /// <summary>
        /// Вес оружия
        /// </summary>
        private double _weight;

        /// <summary>
        /// Getter и Setter для поля _weaponName
        /// </summary>
        public string WeaponName { 
            get { return _weaponName; }
            set { _weaponName = value; }
        }

        /// <summary>
        /// Getter и Setter для поля _degreeOfDanger
        /// </summary>
        public double DegreeOfDanger {
            get { return _degreeOfDanger; } 
            set { _degreeOfDanger = value;}
        }

        /// <summary>
        /// Getter и Setter для поля _weight
        /// </summary>
        public double Weight { 
            get { return _weight; } 
            set { _weight = value; }
        }


        /// <summary>
        /// Конструктор базового класса Weapon
        /// </summary>
        /// <param name="parWeaponName"></param>
        /// <param name="parWeight"></param>
        /// <param name="parDegreeOfDanger"></param>

        public Weapon(string parWeaponName, double parWeight, double parDegreeOfDanger) 
        {
            _Id = Guid.NewGuid();
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
            return string.Format("Weapon id = {0}, Weapon name = {1}, Weapon parWeight = {2}, Weapon parWeight = {3}", _Id, _weaponName, _weight, _degreeOfDanger);
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
