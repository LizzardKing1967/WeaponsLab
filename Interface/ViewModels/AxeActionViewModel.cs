using Interface.ManipulationUtils;
using Interface.Model;
using Interface.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeaponsLib;

namespace Interface
{
    /// <summary>
    /// ViewModel для действий с топором.
    /// </summary>
    class AxeActionViewModel : WeaponActionViewModelBase<Axe>
    {
        /// <summary>
        /// Скорость удара.
        /// </summary>
        double _strikeRate;

        /// <summary>
        /// Степень заточки.
        /// </summary>
        double _degreeOfSharpening;

        /// <summary>
        /// Длина рукояти.
        /// </summary>
        int _handleLength; 

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
        /// Длина рукояти.
        /// </summary>
        public int HandleLength
        {
            get { return _handleLength; }
            set
            {
                _handleLength = value;
                OnPropertyChanged(nameof(HandleLength));
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса AxeActionViewModel для редактирования или удаления топора.
        /// </summary>
        /// <param name="parAxe">Экземпляр топора.</param>
        /// <param name="parOperationMode">Режим выполнения операции.</param>
        /// <param name="parWeaponRepository">Репозиторий оружия.</param>
        public AxeActionViewModel(Axe parAxe, OperationMode parOperationMode, WeaponRepository parWeaponRepository) : base(parAxe, parOperationMode, parWeaponRepository)
        {
            if (parAxe != null)
            {
                DegreeOfDanger = parAxe.DegreeOfDanger;
                StrikeRate = parAxe.StrikeRate;
                DegreeOfSharpening = parAxe.DegreeOfSharpening;
                HandleLength = parAxe.HandleLength;
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса AxeActionViewModel для добавления топора.
        /// </summary>
        /// <param name="parOperationMode">Режим выполнения операции.</param>
        /// <param name="parWeaponRepository">Репозиторий оружия.</param>
        public AxeActionViewModel(OperationMode parOperationMode, WeaponRepository parWeaponRepository) : base(parOperationMode, parWeaponRepository)
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
                    _weaponRepository.EditWeapon(_weapon, new Axe(WeaponName, Weight, DegreeOfDanger, StrikeRate, DegreeOfSharpening, HandleLength));
                    break;
                case OperationMode.Delete:
                    _weaponRepository.RemoveWeapon(_weapon);
                    break;
                case OperationMode.Add:
                    _weapon = new Axe(WeaponName, Weight, DegreeOfDanger, StrikeRate, DegreeOfSharpening, HandleLength);
                    _weaponRepository.AddWeapon(_weapon);
                    break;
            }
            ActionCompleted = true;
            CloseWindow();
        }
    }
}
