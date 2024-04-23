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
    /// <summary>
    /// Главная ViewModel приложения, управляющая основным представлением и манипуляциями с оружием.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Флаг, указывающий, была ли уже выполнена команда GenerateTestDataCommand.
        /// </summary>
        private bool _isTestDataGenerated = false;

        /// <summary>
        /// Словарь со всеми классами для редактирования и удаления объектов типа Weapon
        /// </summary>
        private readonly Dictionary<Type, WeaponEditor> _editors = new Dictionary<Type, WeaponEditor>();

        /// <summary>
        /// Репозиторий оружия
        /// </summary>
        private readonly WeaponRepository _weaponModel; 

        /// <summary>
        /// Коллекция оружия.
        /// </summary>
        public ObservableCollection<Weapon> Weapons => _weaponModel.Weapons;

        /// <summary>
        /// Выбранное оружие.
        /// </summary>
        private Weapon _selectedWeapon;

        /// <summary>
        /// Getter и Setter для выбранного оружия.
        /// </summary>
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

        /// <summary>
        /// Возвращает значение, указывающее, выбрано ли какое-либо оружие.
        /// </summary>
        public bool IsItemSelected => SelectedWeapon != null;

        /// <summary>
        /// Команда для добавления меча
        /// </summary>
        public ICommand AddSwordCommand { get; }

        /// <summary>
        /// Команда для добавления топора
        /// </summary>
        public ICommand AddAxeCommand { get; }

        /// <summary>
        /// Команда для добавления винтовки
        /// </summary>
        public ICommand AddRifleCommand { get; }

        /// <summary>
        /// Команда для добавления пистолета
        /// </summary>
        public ICommand AddPistolCommand { get; }

        /// <summary>
        /// Команда для редактирования выбранного оружия
        /// </summary>
        public ICommand EditCommand { get; }

        /// <summary>
        /// Команда для удаления выбранного оружия
        /// </summary>
        public ICommand DeleteCommand { get; }

        /// <summary>
        /// Команда для генерации тестовых данных
        /// </summary>
        public ICommand GenerateTestDataCommand { get; }


        /// <summary>
        /// Инициализирует новый экземпляр класса MainViewModel.
        /// </summary>
        public MainViewModel()
        {
            _weaponModel = new WeaponRepository();

            // Инициализация редакторов для каждого типа оружия
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

        /// <summary>
        /// Методы проверки возможности редактирования выбранного оружия.
        /// </summary>
        /// <returns>Bool значение возможности редактирования</returns>
        private bool CanEditWeapon() => SelectedWeapon != null;

        /// <summary>
        /// Методы проверки возможности удаления выбранного оружия.
        /// </summary>
        /// <returns>Bool значение возможности удаления</returns>
        private bool CanDeleteWeapon() => SelectedWeapon != null;

        /// <summary>
        /// Метод для добавления меча
        /// </summary>
        private void AddSword()
        {
            SwordActionViewModel swordActionViewModel = new SwordActionViewModel(OperationMode.Add, _weaponModel);
            SwordView swordView = new SwordView();
            swordView.DataContext = swordActionViewModel;
            swordView.ShowDialog();
        }

        /// <summary>
        /// Метод для добавления топора
        /// </summary>
        private void AddAxe()
        {
            AxeActionViewModel axeActionViewModel = new AxeActionViewModel(OperationMode.Add, _weaponModel);
            AxeWindow axeActionView = new AxeWindow();
            axeActionView.DataContext = axeActionViewModel;
            axeActionView.ShowDialog();
        }

        /// <summary>
        /// Метод для добавления винтовки
        /// </summary>
        private void AddRifle()
        {
            RifleActionViewModel rifleActionViewModel = new RifleActionViewModel(OperationMode.Add, _weaponModel);
            RifleView rifleView = new RifleView();
            rifleView.DataContext = rifleActionViewModel;
            rifleView.ShowDialog();
        }

        /// <summary>
        /// Метод для добавления пистолета
        /// </summary>
        private void AddPistol()
        {
            PistolActionViewModel pistolViewModel = new PistolActionViewModel(OperationMode.Add, _weaponModel);
            PistolWindow pistolWindow = new PistolWindow();
            pistolWindow.DataContext = pistolViewModel;
            pistolWindow.ShowDialog();
        }

        /// <summary>
        /// Методы для редактирования выбранного оружия
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        /// Методы для удаления выбранного оружия
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        /// Метод для генерации тестовых данных.
        /// </summary>
        private void GenerateTestData()
        {
            if (!_isTestDataGenerated)
            {
                _weaponModel.AddWeapon(new Rifle("AKM", 3.5, 80, 60, _weaponModel.Calibers[2], 30, 0));
                _weaponModel.AddWeapon(new Rifle("M16", 3, 70, 70, _weaponModel.Calibers[3], 30, 0));
                _weaponModel.AddWeapon(new Pistol("Glock17", 2, 30, 30, _weaponModel.Calibers[1], 15, false));
                _weaponModel.AddWeapon(new Pistol("Colt-1911", 2, 40, 20, _weaponModel.Calibers[0], 7, true));
                _weaponModel.AddWeapon(new Axe("Fire Axe", 7.5, 90, 12, 7, 40));
                _weaponModel.AddWeapon(new Sword("Escalibur", 6, 80, 18, 7, true));
                _isTestDataGenerated = true;
            }
        }

        /// <summary>
        /// Метод, вызываемый при освобождении ресурсов.
        /// </summary>
        protected override void OnDispose()
        {
            this.Weapons.Clear();
        }
    }
}
