using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponsLib
{

    /// <summary>
    /// Базовый класс для ручного оружия
    /// </summary>
    public abstract class Weapon : INotifyPropertyChanged
    {
        /// <summary>
        /// Идентификатор класса
        /// </summary>
        private Guid _id;

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
        /// Событие, возникающее при изменении значения свойства.
        /// Это событие используется для уведомления привязанных данных (например, в интерфейсе WPF) о том, что одно из свойств объекта было изменено.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Getter и Setter для поля _weaponName
        /// </summary>
        public string WeaponName { 
            get { return _weaponName; }
            set 
            { 
                _weaponName = value;
                OnPropertyChanged(nameof(WeaponName));
            }
        }

        public Guid Id
        {
            get { return _id; }
        }

        /// <summary>
        /// Getter и Setter для поля _degreeOfDanger
        /// </summary>
        public double DegreeOfDanger {
            get { return _degreeOfDanger; } 
            set 
            { 
                _degreeOfDanger = value;
                OnPropertyChanged(nameof(DegreeOfDanger));
            }
        }

        /// <summary>
        /// Getter и Setter для поля _weight
        /// </summary>
        public double Weight 
        { 
            get { return _weight; } 
            set 
            { 
                _weight = value; 
                OnPropertyChanged(nameof(Weight));
            }
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Weapon()
        {
            _id = Guid.NewGuid();
            this._weaponName = string.Empty;
            this._degreeOfDanger = 0;
            this._weight = 0;
        }

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="parWeapon">Оружие, свойства которого нужно копировать</param>
        public Weapon(Weapon parWeapon)
        {
            this._weaponName = parWeapon.WeaponName;
            this._degreeOfDanger = parWeapon.DegreeOfDanger;
            this._weight = parWeapon.Weight;
        }


        /// <summary>
        /// Конструктор базового класса Weapon
        /// </summary>
        /// <param name="parWeaponName">Название оружия</param>
        /// <param name="parWeight">Вес оружия</param>
        /// <param name="parDegreeOfDanger">Опасность оружия</param>

        public Weapon(string parWeaponName, double parWeight, double parDegreeOfDanger) 
        {
            _id = Guid.NewGuid();
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
            return string.Format("Weapon id = {0}, Weapon name = {1}, Weapon parWeight = {2}, Weapon parWeight = {3}", _id, _weaponName, _weight, _degreeOfDanger);
        }

        /// <summary>
        /// Метод оценки урона от оружия
        /// </summary>
        /// <returns></returns>
        public virtual double GetDamage()
        {
            return _degreeOfDanger;
        }

        /// <summary>
        /// Редактирует поля текущего оружия на основе данных нового оружия.
        /// </summary>
        /// <param name="newWeapon">Новое оружие с обновленными данными.</param>
        public virtual void EditWeapon(Weapon newWeapon)
        {
            if (newWeapon != null)
            {
                this.WeaponName = newWeapon.WeaponName;
                this.Weight = newWeapon.Weight;
                this.DegreeOfDanger = newWeapon.DegreeOfDanger;
            }
            else
            {
                throw new ArgumentNullException(nameof(newWeapon), "New weapon cannot be null.");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Получить копию объекта
        /// </summary>
        /// <returns>Копия</returns>
        public abstract object Clone();
    

    }

}
