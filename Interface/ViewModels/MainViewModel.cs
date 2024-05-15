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
using Factories;
using Interface.ViewModel;
using Interface.Utils;
using ProcessingForm;
using Interface.DataUtils;

namespace Interface
{
    /// <summary>
    /// Главная ViewModel приложения, управляющая основным представлением и манипуляциями с оружием.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Выбранная фабрика
        /// </summary>
        private IFactory _selectedFactory;

        /// <summary>
        /// Выбранный метод создания фабрики
        /// </summary>
        private FactoryMethod _selectedFactoryMethod;

        /// <summary>
        /// Список фабричных методов для создания фабрик
        /// </summary>
        private List<FactoryMethod> _factoryMethods = new List<FactoryMethod>()
        {
            new HeavyWeaponsFactoryCreator(),
            new LightWeaponsFactoryCreator(),
            new PrototypeFactoryCreator(),
        };

        /// <summary>
        /// Константа количества оружия по умолчанию
        /// </summary>
        const int DEFAULT_RANDOM_WEAPONS_COUNT = 1000000;


        /// <summary>
        /// Флаг, указывающий, была ли уже выполнена команда GenerateTestDataCommand.
        /// </summary>
        private bool _isTestDataGenerated = false;

        /// <summary>
        /// Значение, определяющие, будет ли форма генерации закрыта по завершению
        /// </summary>
        private bool _isCloseAfterCompleted;

        /// <summary>
        /// Словарь со всеми классами для получения форм для объектов типа Weapon
        /// </summary>
        private readonly Dictionary<Type, WeaponViewGetter> _viewGetters = new Dictionary<Type, WeaponViewGetter>();

        /// <summary>
        /// Репозиторий оружия
        /// </summary>
        private readonly WeaponRepository _weaponModel;

        /// <summary>
        /// Выбранное оружие.
        /// </summary>
        protected Weapon _selectedWeapon;
        
        /// <summary>
        /// Количество случайных единиц оружия для создания
        /// </summary>
        private int _randomWeaponsCount;

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
        /// Коллекция оружия.
        /// </summary>
        public ObservableCollection<Weapon> Weapons => _weaponModel.Weapons;

        /// <summary>
        /// Возвращает значение, указывающее, выбрано ли какое-либо оружие.
        /// </summary>
        public bool IsItemSelected => SelectedWeapon != null;

        /// <summary>
        /// Возвращает значение, указывающее, выбрана ли фабрика
        /// </summary>
        public bool IsFactorySelected => SelectedFactory != null;

        /// <summary>
        /// Выбранная фабрика
        /// </summary>
        public IFactory SelectedFactory
        {
            get { return _selectedFactory; }
            set
            {
                _selectedFactory = value;
                OnPropertyChanged(nameof(SelectedFactory));
            }
        }

        /// <summary>
        /// Выбранный метод создания фабрики, при выборе инициализирует фабрику
        /// </summary>
        public FactoryMethod SelectedMethod
        {
            get { return _selectedFactoryMethod; }
            set
            {
                _selectedFactoryMethod = value;
                SelectedFactory = _selectedFactoryMethod.CreateFactory();
                OnPropertyChanged(nameof(IsFactorySelected));
            }
        }

        /// <summary>
        /// Список фабричных методов для создания фабрик
        /// </summary>
        public List<FactoryMethod> FactoryMethods
        {
            get
            {
                return _factoryMethods;
            }
            set 
            {
                _factoryMethods = value;
            }
            
        }

        /// <summary>
        ///  Количество случайных единиц оружия для создания
        /// </summary>
        public int RandomWeaponsCount
        {
            get => _randomWeaponsCount;
            set { _randomWeaponsCount = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsCloseAfterCompleted
        {
            get => _isCloseAfterCompleted;
            set { _isCloseAfterCompleted = value; }
        }

        /// <summary>
        /// Команда для добавления огнестрельного оружия
        /// </summary>
        public ICommand AddFirearmCommand { get; }

        /// <summary>
        /// Команда для добавления холодного оружия
        /// </summary>
        public ICommand AddSteelarmCommand { get; }

        /// <summary>
        /// Команда для редактирования оружия
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
        /// Команда для генерации случайных тестовых данных
        /// </summary>
        public ICommand GenerateRandomDataCommand { get; }

        /// <summary>
        /// Инициализирует новый экземпляр класса MainViewModel.
        /// </summary>
        public MainViewModel()
        {
            _weaponModel = new WeaponRepository();
            RandomWeaponsCount = DEFAULT_RANDOM_WEAPONS_COUNT;
            IsCloseAfterCompleted = true;
            // Инициализация редакторов для каждого типа оружия
            _viewGetters[typeof(Sword)] = new SwordViewGetter(_weaponModel);
            _viewGetters[typeof(Axe)] = new AxeViewGetter(_weaponModel);
            _viewGetters[typeof(Pistol)] = new PistoViewGetter(_weaponModel);
            _viewGetters[typeof(Rifle)] = new RifleViewGetter(_weaponModel);
            AddFirearmCommand = new RelayCommand(AddFirearm, CanAddWeapon);
            AddSteelarmCommand = new RelayCommand(AddSteelarm, CanAddWeapon);
            EditCommand = new RelayCommand(EditWeapon, CanEditWeapon);
            DeleteCommand = new RelayCommand(DeleteWeapon, CanDeleteWeapon);
            GenerateTestDataCommand = new RelayCommand(GenerateTestData);
            GenerateRandomDataCommand = new RelayCommand(GenerateRandomData);
        }

        /// <summary>
        /// Методы проверки возможности добавления оружия.
        /// </summary>
        /// <returns></returns>
        private bool CanAddWeapon() => SelectedFactory != null;

        /// <summary>
        /// Методы проверки возможности редактирования выбранного оружия.
        /// </summary>
        /// <returns>Bool значение возможности редактирования</returns>
        private bool CanEditWeapon() => IsItemSelected;

        /// <summary>
        /// Методы проверки возможности удаления выбранного оружия.
        /// </summary>
        /// <returns>Bool значение возможности удаления</returns>
        private bool CanDeleteWeapon() => IsItemSelected;

        /// <summary>
        /// Метод для добавления огнестрельного оружия
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        private void AddFirearm()
        {
            if (SelectedFactory != null)
            {
                Firearm createdFirearm = SelectedFactory.CreateFirearm();
                // Получаем тип созданного оружия
                Type weaponType = createdFirearm.GetType();
                // Получаем редактор для выбранного типа оружия и вызываем метод GetView
                if (_viewGetters.TryGetValue(weaponType, out WeaponViewGetter editor))
                {
                    editor.GetView(createdFirearm, OperationMode.Add);
                    OnPropertyChanged(nameof(Weapons));
                    if (Weapons.LastOrDefault() != null)
                    {
                        SelectedWeapon = Weapons.LastOrDefault();
                    }

                }
                else
                {
                    throw new ArgumentException("Unsupported weapon type");
                }
            }
        }
        /// <summary>
        /// Метод для добавления холодного оружия
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        private void AddSteelarm()
        {
            if (SelectedFactory != null)
            {
                SteelArm createdSteealarm = SelectedFactory.CreateSteelArm();
                // Получаем тип созданного оружия
                Type weaponType = createdSteealarm.GetType();
                // Получаем редактор для выбранного типа оружия и вызываем метод GetView
                if (_viewGetters.TryGetValue(weaponType, out WeaponViewGetter editor))
                {
                    editor.GetView(createdSteealarm, OperationMode.Add);
                    OnPropertyChanged(nameof(Weapons));
                    if (Weapons.LastOrDefault() != null)
                    {
                        SelectedWeapon = Weapons.LastOrDefault();
                    }
                }
                else
                {
                    throw new ArgumentException("Unsupported weapon type");
                }
            }
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
                // Получаем редактор для выбранного типа оружия и вызываем метод GetView
                if (_viewGetters.TryGetValue(weaponType, out WeaponViewGetter editor))
                {
                    editor.GetView(SelectedWeapon, OperationMode.Edit);
                    OnPropertyChanged(nameof(Weapons));
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
                if (_viewGetters.TryGetValue(weaponType, out WeaponViewGetter editor))
                {
                    editor.GetView(SelectedWeapon, OperationMode.Delete);
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
                _weaponModel.AddWeapon(new Rifle("AKM", 3.5, 80, 60, CalibersRepository.Calibers[2], 30, 0));
                _weaponModel.AddWeapon(new Rifle("M16", 3, 70, 70, CalibersRepository.Calibers[3], 30, 0));
                _weaponModel.AddWeapon(new Pistol("Glock17", 2, 30, 30, CalibersRepository.Calibers[1], 15, false));
                _weaponModel.AddWeapon(new Pistol("Colt-1911", 2, 40, 20, CalibersRepository.Calibers[0], 7, true));
                _weaponModel.AddWeapon(new Axe("Fire Axe", 7.5, 90, 12, 7, 40));
                _weaponModel.AddWeapon(new Sword("Escalibur", 6, 80, 18, 7, true));
                _isTestDataGenerated = true;
            }
        }

        private void GenerateRandomData()
        {
            if (RandomWeaponsCount > 0)
            {
                LoadingForm processingForm = new LoadingForm(RandomWeaponsCount, IsCloseAfterCompleted, RandomWeaponGenerator.CreateRandomWeapon, AddRandomData);
                processingForm.Show();
            }

        }

        private void AddRandomData(List<object> parWeapons)
        {
            parWeapons.ForEach(weapon => _weaponModel.AddWeapon((Weapon)weapon));
            OnPropertyChanged(nameof(WeaponRepository));
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
