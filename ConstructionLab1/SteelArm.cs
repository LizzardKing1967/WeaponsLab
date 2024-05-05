using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLib
{
    /// <summary>
    /// Класс холодного оружия SteealArm, наследник от класа Weapon
    /// </summary>
    public class SteelArm : Weapon
    {

        /// <summary>
        /// Скорость удара холодным оружием
        /// </summary>
        private double _strikeRate;
       
        /// <summary>
        /// Степень заточки оружия
        /// </summary>
        private double _degreeOfSharpening;

        /// <summary>
        /// Getter и Setter для поля _degreeOfSharpening
        /// </summary>
        public double DegreeOfSharpening {
            get { return this._degreeOfSharpening; } 
            set 
            { 
                _degreeOfSharpening = value;
                OnPropertyChanged(nameof(DegreeOfSharpening));
            }
        }

        /// <summary>
        /// Getter и Setter для поля _strikeRate
        /// </summary>
        public double StrikeRate { 
            get { return this._strikeRate; } 
            set 
            { 
                this._strikeRate = value; 
                OnPropertyChanged(nameof(StrikeRate));
            }
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public SteelArm() : base()
        {
            this._degreeOfSharpening = 0;
            this._strikeRate = 0;
        }

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="parSteelArm">Холодное оружие, свойства которого нужно копировать</param>
        public SteelArm(SteelArm parSteelArm) : base(parSteelArm)
        {
            this._degreeOfSharpening = parSteelArm._degreeOfSharpening;
            this._strikeRate = parSteelArm._strikeRate;
        }

        /// <summary>
        /// Конструктор для класса SteelArm
        /// </summary>
        /// <param name="parWeaponName">Название оружия</param>
        /// <param name="parWeight">Вес оружия</param>
        /// <param name="parDegreeOfDanger">Степень опасности оружия</param>
        /// <param name="parStrikeRate">Скорость удара</param>
        /// <param name="parDegreeOfSharpening">Степень заточки/param>
        public SteelArm(string parWeaponName, double parWeight, double parDegreeOfDanger, double parStrikeRate, double parDegreeOfSharpening) : base(parWeaponName, parWeight, parDegreeOfDanger)
        {
            this._strikeRate = parStrikeRate;
            this._degreeOfSharpening = parDegreeOfSharpening;

        }
       
        /// <summary>
        /// Метод удара холодным оружием по цели
        /// </summary>
        /// <param name="parTarget">Цель для удара</param>
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

        /// <summary>
        /// Редактирует поля холодного оружия на основе данных нового оружия.
        /// </summary>
        /// <param name="newWeapon">Новое оружие с обновленными данными.</param>
        public override void EditWeapon(Weapon newWeapon)
        {
            base.EditWeapon(newWeapon);
            SteelArm newSteelArm = (SteelArm)newWeapon;
            this.DegreeOfSharpening = newSteelArm.DegreeOfSharpening;
            this.StrikeRate = newSteelArm.StrikeRate;
        }

        /// <summary>
        /// Получить копию
        /// </summary>
        /// <returns>Копия</returns>
        public override object Clone()
        {
            return new SteelArm(this); 
        }

    }
}
