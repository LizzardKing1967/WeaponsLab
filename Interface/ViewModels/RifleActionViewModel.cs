using Interface.Model;
using Interface.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponsLib;

namespace Interface.ViewModel
{
    /// <summary>
    /// ViewModel для действий с винтовкой.
    /// </summary>
    public class RifleActionViewModel : WeaponActionViewModelBase<Rifle>
    {
        /// <summary>
        /// Скорострельность
        /// </summary>
        private int _fireRate;

        /// <summary>
        /// Вместимость боеприпасов.
        /// </summary>
        private int _ammoCapacity;

        /// <summary>
        /// Текущая вместимость.
        /// </summary>
        private int _currentCapacity;

        /// <summary>
        /// Калибр
        /// </summary>
        private Caliber _caliber;

        /// <summary>
        /// Дальность пристрелки.
        /// </summary>
        private int _range; 

        /// <summary>
        /// Текущая вместимость боеприпасов.
        /// </summary>
        public int CurrentCapacity
        {
            get => _currentCapacity;
            set => _ammoCapacity = value;
        }

        /// <summary>
        /// Калибр.
        /// </summary>
        public Caliber CaliberProperty
        {
            get { return this._caliber; }
            set
            {
                _caliber = value;
                OnPropertyChanged(nameof(CaliberProperty));
            }
        }

        /// <summary>
        /// Скорострельность.
        /// </summary>
        public int FireRate
        {
            get { return _fireRate; }
            set
            {
                _fireRate = value;
                OnPropertyChanged(nameof(FireRate));
            }
        }

        /// <summary>
        /// Вместимость боеприпасов.
        /// </summary>
        public int AmmoCapacity
        {
            get { return _ammoCapacity; }
            set
            {
                _ammoCapacity = value;
                OnPropertyChanged(nameof(AmmoCapacity));
            }
        }

        /// <summary>
        /// Дальность пристрелки.
        /// </summary>
        public int Range
        {
            get { return _range; }
            set
            {
                _range = value;
                OnPropertyChanged(nameof(Range));
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса RifleActionViewModel для редактирования или удаления винтовки.
        /// </summary>
        /// <param name="parRifle">Экземпляр винтовки.</param>
        /// <param name="parOperationMode">Режим выполнения операции.</param>
        /// <param name="parWeaponRepository">Репозиторий оружия.</param>
        public RifleActionViewModel(Rifle parRifle, OperationMode parOperationMode, WeaponRepository parWeaponRepository) : base(parRifle, parOperationMode, parWeaponRepository)
        {
            if (parRifle != null)
            {
                FireRate = parRifle.FireRate;
                AmmoCapacity = parRifle.AmmoCapacity;
                Range = parRifle.Range;
                CaliberProperty = parRifle.CaliberProperty;
                CurrentCapacity = parRifle.CurentCapacity;
            }
        }

        /// <summary>
        /// Выполняет выбранное действие в зависимости от текущего режима.
        /// </summary>
        protected override void Action()
        {
            switch (CurrentMode)
            {
                case OperationMode.Edit:
                    Weapon.EditWeapon(new Rifle(WeaponName, Weight, DegreeOfDanger, FireRate, CaliberProperty, AmmoCapacity, Range));
                    break;
                case OperationMode.Delete:
                    _weaponRepository.RemoveWeapon(Weapon);
                    break;
                case OperationMode.Add:
                    Weapon.EditWeapon(new Rifle(WeaponName, Weight, DegreeOfDanger, FireRate, CaliberProperty, AmmoCapacity, Range));
                    _weaponRepository.AddWeapon(Weapon);
                    break;
                case OperationMode.Initialize:
                    Weapon.EditWeapon(new Rifle(WeaponName, Weight, DegreeOfDanger, FireRate, CaliberProperty, AmmoCapacity, Range));
                    break;
            }
            CloseWindow();
            ActionCompleted = true;
        }
    }
}
