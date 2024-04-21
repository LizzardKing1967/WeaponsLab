using Client.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeaponsLib;

namespace Client
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
        
        int _handleLength;
        public string WindowTitle { get; }
        public string ButtonText { get; }


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

        public AxeActionViewModel(Axe axe, string windowTitle, string buttonText, WeaponRepository weaponRepository)
        {
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

            WindowTitle = windowTitle;
            ButtonText = buttonText;

            // Инициализация команды
            ActionCommand = new RelayCommand(Action);
            _weaponRepository = weaponRepository;
        }

        public AxeActionViewModel(string windowTitle, string buttonText, WeaponRepository weaponRepository)
        {

            WindowTitle = windowTitle;
            ButtonText = buttonText;

            // Инициализация команды
            ActionCommand = new RelayCommand(Action);
            _weaponRepository = weaponRepository;
        }

        private void Action()
        {
            // Логика для добавления топора
            // Создаем новый экземпляр топора на основе введенных данных
            _axe = new Axe(WeaponName, Weight, DegreeOfDanger, StrikeRate,DegreeOfSharpening,HandleLength);
            _weaponRepository.AddWeapon(_axe);
            CloseWindow();
        }

        private void CloseWindow()
        {
            // Получаем ссылку на текущее окно
            System.Windows.Window window = System.Windows.Application.Current.Windows.OfType<System.Windows.Window>().SingleOrDefault(w => w.DataContext == this);
            if (window != null)
            {
                // Закрываем окно
                window.Close();
            }
        }

    }
}
