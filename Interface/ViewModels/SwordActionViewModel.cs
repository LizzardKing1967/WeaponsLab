using Interface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using WeaponsLib;

namespace Interface.ViewModel
{
    /// <summary>
    /// ViewModel для действий с мечом.
    /// </summary>
    class SwordActionViewModel : WeaponActionViewModelBase<Sword>
    {
        /// <summary>
        /// Скорость удара
        /// </summary>
        double _strikeRate;

        /// <summary>
        /// Степень заточки.
        /// </summary>
        double _degreeOfSharpening;

        /// <summary>
        /// Зачарован ли.
        /// </summary>
        bool _isEnchanted;

        /// <summary>
        /// Скорость удара.
        /// </summary>
        public double StrikeRate
        {
            get { return _strikeRate; }
            set
            {
                _strikeRate = value;
                OnPropertyChanged(nameof(StrikeRate));
            }
        }

        /// <summary>
        /// Степень заточки.
        /// </summary>
        public double DegreeOfSharpening
        {
            get { return _degreeOfSharpening; }
            set
            {
                _degreeOfSharpening = value;
                OnPropertyChanged(nameof(DegreeOfSharpening));
            }
        }

        /// <summary>
        /// Зачарован ли.
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
        /// Инициализирует новый экземпляр класса SwordActionViewModel для редактирования или удаления меча.
        /// </summary>
        /// <param name="parSword">Экземпляр меча.</param>
        /// <param name="parOperationMode">Режим выполнения операции.</param>
        /// <param name="parWeaponRepository">Репозиторий оружия.</param>
        public SwordActionViewModel(Sword parSword, OperationMode parOperationMode, WeaponRepository parWeaponRepository) : base(parSword, parOperationMode, parWeaponRepository)
        {
            if (parSword != null)
            {
                DegreeOfDanger = parSword.DegreeOfDanger;
                StrikeRate = parSword.StrikeRate;
                DegreeOfSharpening = parSword.DegreeOfSharpening;
                IsEnchanted = parSword.IsEnchanted;
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса SwordActionViewModel для добавления меча.
        /// </summary>
        /// <param name="parOperationMode">Режим выполнения операции.</param>
        /// <param name="parWeaponRepository">Репозиторий оружия.</param>
        public SwordActionViewModel(OperationMode parOperationMode, WeaponRepository parWeaponRepository) : base(parOperationMode, parWeaponRepository)
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
                    _weaponRepository.EditWeapon(_weapon, new Sword(WeaponName, Weight, DegreeOfDanger, StrikeRate, DegreeOfSharpening, IsEnchanted));
                    break;
                case OperationMode.Delete:
                    _weaponRepository.RemoveWeapon(_weapon);
                    break;
                case OperationMode.Add:
                    _weapon = new Sword(WeaponName, Weight, DegreeOfDanger, StrikeRate, DegreeOfSharpening, IsEnchanted);
                    _weaponRepository.AddWeapon(_weapon);
                    break;
            }
            CloseWindow();
            ActionCompleted = true;
        }
    }
}
