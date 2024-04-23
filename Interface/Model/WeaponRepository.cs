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
        /// Список калибров.
        /// </summary>
        private List<Caliber> _calibers;

        /// <summary>
        /// Список калибров доступных для оружия.
        /// </summary>
        public List<Caliber> Calibers { get { return _calibers; } }

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
        /// Инициализирует новый экземпляр класса WeaponRepository и инициализирует список оружия и калибров.
        /// </summary>
        public WeaponRepository()
        {
            // Инициализация списка оружия
            Weapons = new ObservableCollection<Weapon>();
            _calibers = new List<Caliber>
            {
                new Caliber(".45ACP", 120),
                new Caliber("9mm", 100),
                new Caliber("7.62mm", 150),
                new Caliber("5.56mm", 130),
            };
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
        /// Редактирует существующее оружие в репозитории.
        /// </summary>
        /// <param name="parOldWeapon">Старое оружие, которое требуется заменить.</param>
        /// <param name="parNewWeapon">Новое оружие, которым требуется заменить старое.</param>
        public void EditWeapon(Weapon parOldWeapon, Weapon parNewWeapon)
        {
            int index = Weapons.IndexOf(parOldWeapon);
            if (index != -1)
            {
                Weapons[index] = parNewWeapon;
            }
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
