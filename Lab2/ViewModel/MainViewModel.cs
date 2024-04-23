using Interface.ManipulationUtils;
using Interface.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeaponsLib;
using Interface.ViewModel;

namespace Interface
{
    class MainViewModel : ViewModelBase
    {
        private readonly Dictionary<Type, WeaponEditor> _editors = new Dictionary<Type, WeaponEditor>();

        private readonly WeaponRepository _weaponModel;
        public ObservableCollection<Weapon> Weapons => _weaponModel.Weapons;

        private Weapon _selectedWeapon;
        public Weapon SelectedWeapon
        {
            get { return _selectedWeapon; }
            set
            {
                _selectedWeapon = value;
                OnPropertyChanged(nameof(SelectedWeapon));
                OnPropertyChanged(nameof(IsItemSelected));
            }
        }

        public bool IsItemSelected => SelectedWeapon != null;

        public ICommand AddSwordCommand { get; }
        public ICommand AddAxeCommand { get; }
        public ICommand AddRifleCommand { get; }
        public ICommand AddPistolCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand GenerateTestDataCommand { get; }

        public MainViewModel()
        {
            _weaponModel = new WeaponRepository();
            _editors[typeof(Sword)] = new SwordEditor(_weaponModel);
            _editors[typeof(Axe)] = new AxeEditor(_weaponModel);
            _editors[typeof(Pistol)] = new PistolEditor(_weaponModel);
            _editors[typeof(Rifle)] = new RifleEditor(_weaponModel);

            // Инициализация команд
            AddSwordCommand = new RelayCommand(AddSword);
            AddAxeCommand = new RelayCommand(AddAxe);
            AddRifleCommand = new RelayCommand(AddRifle);
            AddPistolCommand = new RelayCommand(AddPistol);
            EditCommand = new RelayCommand(EditWeapon, CanEditWeapon);
            DeleteCommand = new RelayCommand(DeleteWeapon, CanDeleteWeapon);
            GenerateTestDataCommand = new RelayCommand(GenerateTestData);
        }

        private bool CanEditWeapon() => SelectedWeapon != null;
        private bool CanDeleteWeapon() => SelectedWeapon != null;


        private void AddSword()
        {
            // Логика для добавления меча
           
        }

        private void AddAxe()
        {
            AxeActionViewModel axeActionViewModel = new AxeActionViewModel(OperationMode.Add, _weaponModel);
            AxeView axeActionView = new AxeView();
            axeActionView.DataContext = axeActionViewModel;
            axeActionView.ShowDialog();

        }

        private void AddRifle()
        {
            // Логика для добавления винтовки
           
        }

        private void AddPistol()
        {
            // Логика для добавления пистолета
           
        }


        private void EditWeapon()
        {
            if (SelectedWeapon != null)
            {
                // Получаем тип выбранного оружия
                Type weaponType = SelectedWeapon.GetType();
                // Получаем редактор для выбранного типа оружия и вызываем метод Edit
                if (_editors.TryGetValue(weaponType, out WeaponEditor editor))
                {
                    editor.Edit(SelectedWeapon);
                }
                else
                {
                    throw new ArgumentException("Unsupported weapon type");
                }
            }
        }

        private void DeleteWeapon()
        {
            if (SelectedWeapon != null)
            {
                Type weaponType = SelectedWeapon.GetType();
                if (_editors.TryGetValue(weaponType, out WeaponEditor editor))
                {
                    editor.Delete(SelectedWeapon);
                }
                else
                {
                    throw new ArgumentException("Unsupported weapon type");
                }
            }

        }
        private void GenerateTestData()
        {
            // Логика для генерации тестовых данных
        }

        protected override void OnDispose()
        {
            this.Weapons.Clear();
        }

    }
}
