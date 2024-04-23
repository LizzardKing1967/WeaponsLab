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
    /// Базовый класс для ViewModel, представляющих действия над оружием.
    /// </summary>
    /// <typeparam name="T">Тип оружия.</typeparam>
    public abstract class WeaponActionViewModelBase<T> : ViewModelBase where T : Weapon
    {
        /// <summary>
        /// Репозиторий оружия.
        /// </summary>
        protected readonly WeaponRepository _weaponRepository;

        /// <summary>
        /// Экземпляр оружия.
        /// </summary>
        protected T _weapon;

        /// <summary>
        /// Название оружия.
        /// </summary>
        protected string _weaponName;

        /// <summary>
        /// Вес оружия.
        /// </summary>
        protected double _weight;

        /// <summary>
        /// Степень опасности оружия.
        /// </summary>
        protected double _degreeOfDanger;

        /// <summary>
        /// Список доступных калибров.
        /// </summary>
        public List<Caliber> Calibers
        {
            get { return _weaponRepository.Calibers; }
        }

        /// <summary>
        /// Название оружия.
        /// </summary>
        public string WeaponName
        {
            get { return _weaponName; }
            set
            {
                _weaponName = value;
                OnPropertyChanged(nameof(WeaponName));
            }
        }

        /// <summary>
        /// Вес оружия.
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
        /// Степень опасности оружия.
        /// </summary>
        public double DegreeOfDanger
        {
            get { return _degreeOfDanger; }
            set
            {
                _degreeOfDanger = value;
                OnPropertyChanged(nameof(DegreeOfDanger));
            }
        }

        /// <summary>
        /// Заголовок окна.
        /// </summary>
        public string WindowTitle { get; }

        /// <summary>
        /// Текст кнопки.
        /// </summary>
        public string ButtonText { get; }

        /// <summary>
        /// Возможность редактирования.
        /// </summary>
        public bool IsEditable { get; set; }

        /// <summary>
        /// Режим действия.
        /// </summary>
        public OperationMode CurrentMode { get; set; }

        /// <summary>
        /// Команда выполнения действия.
        /// </summary>
        public ICommand ActionCommand { get; }

        /// <summary>
        /// Инициализирует новый экземпляр класса WeaponActionViewModelBase.
        /// </summary>
        /// <param name="parOperationMode">Режим выполнения операции.</param>
        /// <param name="parWeaponRepository">Репозиторий оружия.</param>
        protected WeaponActionViewModelBase(OperationMode parOperationMode, WeaponRepository parWeaponRepository)
        {
            CurrentMode = parOperationMode;
            WindowTitle = OperationModeTranslator.GetNameOperationModeForTitle(parOperationMode);
            ButtonText = OperationModeTranslator.GetNameOperationModeForButton(parOperationMode);
            ActionCommand = new RelayCommand(Action);
            _weaponRepository = parWeaponRepository;
            IsEditable = parOperationMode != OperationMode.Delete;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса WeaponActionViewModelBase с заданным оружием.
        /// </summary>
        /// <param name="parWeapon">Оружие.</param>
        /// <param name="parOperationMode">Режим выполнения операции.</param>
        /// <param name="parWeaponRepository">Репозиторий оружия.</param>
        protected WeaponActionViewModelBase(T parWeapon, OperationMode parOperationMode, WeaponRepository parWeaponRepository)
            : this(parOperationMode, parWeaponRepository)
        {
            CurrentMode = parOperationMode;
            if (parWeapon != null)
            {
                _weapon = parWeapon;
                WeaponName = parWeapon.WeaponName;
                Weight = parWeapon.Weight;
                DegreeOfDanger = parWeapon.DegreeOfDanger;
            }
            WindowTitle = OperationModeTranslator.GetNameOperationModeForTitle(parOperationMode);
            ButtonText = OperationModeTranslator.GetNameOperationModeForButton(parOperationMode);
            ActionCommand = new RelayCommand(Action);
            _weaponRepository = parWeaponRepository;
            IsEditable = parOperationMode != OperationMode.Delete;
        }

        /// <summary>
        /// Метод выполнения действия.
        /// </summary>
        protected abstract void Action();

        /// <summary>
        /// Закрытие окна.
        /// </summary>
        protected void CloseWindow()
        {
            var window = System.Windows.Application.Current.Windows
                .OfType<System.Windows.Window>()
                .SingleOrDefault(w => w.DataContext == this);

            window?.Close();
        }
    }
}
