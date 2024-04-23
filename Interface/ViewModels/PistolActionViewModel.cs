using Interface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeaponsLib;

namespace Interface.ViewModel
{
    /// <summary>
    /// ViewModel для действий с пистолетом.
    /// </summary>
    class PistolActionViewModel : WeaponActionViewModelBase<Pistol>
    {
        /// <summary>
        /// Скорострельность.
        /// </summary>
        int _fireRate;

        /// <summary>
        /// Вместимость боеприпасов.
        /// </summary>
        int _ammoCapacity;

        /// <summary>
        /// Текущая вместимость.
        /// </summary>
        int _currentCapacity;

        /// <summary>
        /// Калибр.
        /// </summary>
        Caliber _caliber;

        /// <summary>
        /// Наличие предохранителя.
        /// </summary>
        bool _hasSafety;

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
        /// Наличие предохранителя.
        /// </summary>
        public bool HasSafety
        {
            get { return _hasSafety; }
            set
            {
                _hasSafety = value;
                OnPropertyChanged(nameof(HasSafety));
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса PistolActionViewModel для редактирования или удаления пистолета.
        /// </summary>
        /// <param name="parPistol">Экземпляр пистолета.</param>
        /// <param name="parOperationMode">Режим выполнения операции.</param>
        /// <param name="parWeaponRepository">Репозиторий оружия.</param>
        public PistolActionViewModel(Pistol parPistol, OperationMode parOperationMode, WeaponRepository parWeaponRepository) : base(parPistol, parOperationMode, parWeaponRepository)
        {
            if (parPistol != null)
            {
                FireRate = parPistol.FireRate;
                AmmoCapacity = parPistol.AmmoCapacity;
                HasSafety = parPistol.HasSafety;
                CaliberProperty = parPistol.CaliberProperty;
                CurrentCapacity = parPistol.CurentCapacity;
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса PistolActionViewModel для добавления пистолета.
        /// </summary>
        /// <param name="operationMode">Режим выполнения операции.</param>
        /// <param name="weaponRepository">Репозиторий оружия.</param>
        public PistolActionViewModel(OperationMode parOperationMode, WeaponRepository parWeaponRepository) : base(parOperationMode, parWeaponRepository)
        {

        }

        /// <summary>
        /// Выполняет выбранное действие в зависимости от текущего режима.
        /// </summary>
        protected override void Action()
        {
            switch (CurrentMode)
            {
                case OperationMode.Edit:
                    _weaponRepository.EditWeapon(_weapon, new Pistol(WeaponName, Weight, DegreeOfDanger, FireRate, CaliberProperty, AmmoCapacity, HasSafety));
                    break;
                case OperationMode.Delete:
                    _weaponRepository.RemoveWeapon(_weapon);
                    break;
                case OperationMode.Add:
                    _weapon = new Pistol(WeaponName, Weight, DegreeOfDanger, FireRate, CaliberProperty, AmmoCapacity, HasSafety);
                    _weaponRepository.AddWeapon(_weapon);
                    break;
            }
            CloseWindow();
        }
    }
}
