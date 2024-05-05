using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLib
{
    /// <summary>
    /// Класс Sword, наследник класса SteelArm
    /// </summary>
    public class Sword : SteelArm
    {

        /// <summary>
        /// Зачарован ли меч
        /// </summary>
        private bool _isEnchanted;

        /// <summary>
        /// Getter и Setter для поля _isEnchanted
        /// </summary>
        public bool IsEnchanted
        {
            get { return _isEnchanted; } 
            set 
            { 
                _isEnchanted = value;
                OnPropertyChanged(nameof(IsEnchanted));
            }
        }
        /// <summary>
        /// Конструктор для класса Sword
        /// </summary>
        /// <param name="parWeaponName">Название оружия</param>
        /// <param name="parWeight">Вес оружия</param>
        /// <param name="parStrikeRate">Скорость удара</param>
        /// <param name="parDegreeOfSharpening">Степень заточки</param>
        /// <param name="parIsEnchanted">Флаг, указывающий, зачаровано ли оружие</param>
        public Sword(string parWeaponName, double parWeight, double parDegreeOfDanger, double parDegreeOfSharpening, double parStrikeRate, bool parIsEnchanted)
            : base(parWeaponName, parWeight, parDegreeOfDanger, parStrikeRate, parDegreeOfSharpening)
        {
            this._isEnchanted = parIsEnchanted;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Sword() : base() 
        {
            _isEnchanted = false;
        }

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="parSword">Меч, свойства которого нужно копировать</param>
        public Sword(Sword parSword) : base(parSword) 
        {
            this._isEnchanted = parSword._isEnchanted;
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

        /// <summary>
        /// Редактирует поля меча на основе данных нового оружия.
        /// </summary>
        /// <param name="newWeapon">Новое оружие с обновленными данными.</param>
        public override void EditWeapon(Weapon newWeapon)
        {
            base.EditWeapon(newWeapon);
            Sword? newSword = newWeapon as Sword;
            if (newSword != null)
            {
                this.IsEnchanted = newSword.IsEnchanted;
            }
        }

        /// <summary>
        /// Получить копию
        /// </summary>
        /// <returns>Копия</returns>
        public override object Clone()
        {
            return new Sword(this);
        }
    }
}
