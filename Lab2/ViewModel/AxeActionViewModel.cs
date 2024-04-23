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
    class AxeActionViewModel : ViewModelBase
    {
        private readonly WeaponRepository _weaponRepository;

        private Axe _axe;

        string _weaponName;

        double _weight;

        double _degreeOfDanger; 

        double _strikeRate; 

        double _degreeOfSharpening;

        OperationMode _operationMode;

        int _handleLength;
        public string WindowTitle { get; }
        public string ButtonText { get; }

        private bool _isEditable = true;
        public bool IsEditable
        {
            get { return _isEditable; }
            set
            {
                _isEditable = value;
                OnPropertyChanged(nameof(IsEditable));
            }
        }
        public OperationMode CurrentMode
        {
            get { return _operationMode; }
            set { _operationMode = value; }
        }


        public string WeaponName
        {
            get { return _weaponName; }
            set
            {
                _weaponName = value;
                OnPropertyChanged(nameof(WeaponName));
            }
        }

        public double Weight
        {
            get { return _weight; }
            set
            {
                    _weight = value;
                    OnPropertyChanged(nameof(Weight));         
            }
        }

        public double DegreeOfDanger
        {
            get { return _degreeOfDanger; }
            set
            {
                _degreeOfDanger = value;
                OnPropertyChanged(nameof(DegreeOfDanger));
            }
        }

        public double StrikeRate
        {
            get { return _strikeRate; }
            set
            {
                _strikeRate = value;
                OnPropertyChanged(nameof(StrikeRate));
            }
        }

        public double DegreeOfSharpening
        {
            get { return _degreeOfSharpening; }
            set
            {
                _degreeOfSharpening = value;
                OnPropertyChanged(nameof(DegreeOfSharpening)); 
            }
        }

        public int HandleLength
        {
            get { return _handleLength; }
            set
            { 
                _handleLength = value;
                OnPropertyChanged(nameof(HandleLength));
                
            }
        }


        public ICommand ActionCommand { get; }

        public AxeActionViewModel(Axe axe, OperationMode operationMode , WeaponRepository weaponRepository)
        {
            CurrentMode = operationMode;
            if (axe != null)
            {   
                _axe = axe;
                WeaponName = axe.WeaponName;
                Weight = axe.Weight;
                DegreeOfDanger = axe.DegreeOfDanger;
                StrikeRate = axe.StrikeRate;
                DegreeOfSharpening = axe.DegreeOfSharpening;
                HandleLength = axe.HandleLength;
            }

            WindowTitle = OperationModeTranslator.GetNameOperationModeForTitle(operationMode);
            ButtonText = OperationModeTranslator.GetNameOperationModeForButton(operationMode); 

            // Инициализация команды
            ActionCommand = new RelayCommand(Action);
            _weaponRepository = weaponRepository;
            IsEditable = CurrentMode != OperationMode.Delete;
        }

        public AxeActionViewModel(OperationMode operationMode, WeaponRepository weaponRepository)
        {

            WindowTitle = OperationModeTranslator.GetNameOperationModeForTitle(operationMode); 
            ButtonText = OperationModeTranslator.GetNameOperationModeForButton(operationMode); 

    
            ActionCommand = new RelayCommand(Action);
            _weaponRepository = weaponRepository;
        }

        private void Action()
        {
            switch (CurrentMode)
            {
                case OperationMode.Edit:
                    _weaponRepository.EditWeapon(_axe, new Axe(WeaponName, Weight, DegreeOfDanger, StrikeRate, DegreeOfSharpening, HandleLength));
                    break;
                case OperationMode.Delete:
                    _weaponRepository.RemoveWeapon(_axe);
                    break;
                case OperationMode.Add:
                    _axe = new Axe(WeaponName, Weight, DegreeOfDanger, StrikeRate, DegreeOfSharpening, HandleLength);
                    _weaponRepository.AddWeapon(_axe);
                    break;
            }
            CloseWindow();
        }

        private void CloseWindow()
        {
            System.Windows.Window window = System.Windows.Application.Current.Windows.OfType<System.Windows.Window>().SingleOrDefault(w => w.DataContext == this);
            if (window != null)
            {
                window.Close();
            }
        }



    }
}
