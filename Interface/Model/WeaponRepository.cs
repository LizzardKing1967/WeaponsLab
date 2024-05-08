using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponsLib;

namespace Interface.Model
{
    /// <summary>
    /// Класс, представляющий репозиторий оружия.
    /// </summary>
    public class WeaponRepository : INotifyPropertyChanged
    {
        /// <summary>
        /// Коллекция объектов оружия.
        /// </summary>
        private ObservableCollection<Weapon> _weapons;

        /// <summary>
        /// Коллекция объектов оружия.
        /// </summary>
        public ObservableCollection<Weapon> Weapons
        {
            get { return _weapons; }
            set
            {
                _weapons = value;
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса _weaponRepository и инициализирует список оружия и калибров.
        /// </summary>
        public WeaponRepository()
        {
            // Инициализация списка оружия и калибра
            Weapons = new ObservableCollection<Weapon>();
        }

        /// <summary>
        /// Добавляет оружие в репозиторий.
        /// </summary>
        /// <param name="parWeapon">Добавляемое оружие.</param>
        public void AddWeapon(Weapon parWeapon)
        {
            Weapons.Add(parWeapon);
        }

        /// <summary>
        /// Удаляет оружие из репозитория.
        /// </summary>
        /// <param name="parWeapon">Оружие, которое требуется удалить.</param>
        public void RemoveWeapon(Weapon parWeapon)
        {
            Weapons.Remove(parWeapon);
        }

        /// <summary>
        /// Событие, возникающее при изменении свойств объекта.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
