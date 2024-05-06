using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLib
{
    /// <summary>
    /// Класс Axe, наследник класса SteelArm
    /// </summary>
    public class Axe : SteelArm
    {
        /// <summary>
        /// Длина рукоятки топора
        /// </summary>
        private int _handleLength;

        /// <summary>
        /// Getter и Setter для поля _handleLength
        /// </summary>
        public int HandleLength { 
            get { return _handleLength; }
            set { 
                _handleLength = value; 
                OnPropertyChanged(nameof(HandleLength));
            }  
        }

        /// <summary>
        /// Конструктор класса Axe
        /// </summary>
        /// <param name="parWeaponName">Название оружия</param>
        /// <param name="parWeight">Вес оружия</param>
        /// <param name="parDegreeOfDanger">Опасность оружия</param>
        /// <param name="parStrikeRate">Скорость удара</param>
        /// <param name="parDegreeOfSharpening">Степень заточки</param>
        /// <param name="parHandleLength">Длина рукояти</param>
        public Axe(string parWeaponName, double parWeight, double parDegreeOfDanger, double parStrikeRate, double parDegreeOfSharpening, int parHandleLength)
            : base(parWeaponName, parWeight, parDegreeOfDanger ,parStrikeRate, parDegreeOfSharpening)
        {
            this._handleLength = parHandleLength;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Axe() : base() 
        {
            this._handleLength = 0;
        }

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="parAxe">Топор, свойства которого нужно копировать</param>
        public Axe(Axe parAxe) : base(parAxe)
        {
            this._handleLength = parAxe.HandleLength; 
        }

        /// <summary>
        /// Метод класса, отвечающий за расширение рукоятки топора
        /// </summary>
        /// <param name="parLength">Длина рукоятки</param>
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

        /// <summary>
        /// Редактирует поля топора на основе данных нового оружия.
        /// </summary>
        /// <param name="newWeapon">Новое оружие с обновленными данными.</param>
        public override void EditWeapon(Weapon newWeapon)
        {
            base.EditWeapon(newWeapon);
            Axe? newAxe = newWeapon as Axe;
            if (newAxe != null)
            {
                this.HandleLength = newAxe.HandleLength;
            }
        }

        /// <summary>
        /// Получить копию
        /// </summary>
        /// <returns>Копия</returns>
        public override object Clone()
        {
            return new Axe(this);
        }
    }
}
