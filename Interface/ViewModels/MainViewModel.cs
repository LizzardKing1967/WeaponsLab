using Interface.ManipulationUtils;
using Interface.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WeaponsLib;
using Factories;
using Interface.Utils;
using ProcessingForm;
using Interface.DataUtils;
using Interface.FilterUtils;
using System.Windows.Data;

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
        /// Последнее выбранное оружие перед фильтрацией.
        /// </summary>
        private Weapon _lastSelectedWeapon;

        /// <summary>
        /// Сервис для фильтрации списка оружия.
        /// </summary>
        private readonly IFiltrable<Weapon> _filtration;

        /// <summary>
        /// Текстовое значение для фильтрации по названию.
        /// </summary>
        private string _filterText;

        /// <summary>
        /// Числовое значение для фильтрации.
        /// </summary>
        private double? _filterNumericValue;

        /// <summary>
        /// Текстовое представление числового значения для фильтрации.
        /// </summary>
        private string _filterNumericValueText;

        /// <summary>
        /// Текстовое представление минимального числового значения для фильтрации по диапазону.
        /// </summary>
        private string _filterNumericValueMinText;

        /// <summary>
        /// Текстовое представление максимального числового значения для фильтрации по диапазону.
        /// </summary>
        private string _filterNumericValueMaxText;

        /// <summary>
        /// Источник данных для представления отфильтрованного списка оружия.
        /// </summary>
        private CollectionViewSource _filteredWeapons;

        /// <summary>
        /// Выбранный тип фильтрации.
        /// </summary>
        private FilterTypeItem _selectedFilterType;

        /// <summary>
        /// Минимальное значение для фильтрации по диапазону.
        /// </summary>
        private double? _filterNumericValueMin;

        /// <summary>
        /// Максимальное значение для фильтрации по диапазону.
        /// </summary>
        private double? _filterNumericValueMax;

        /// <summary>
        /// Возвращает коллекцию доступных типов фильтров для оружия.
        /// Каждый фильтр позволяет выбирать, по какому критерию будет выполняться фильтрация: 
        /// по названию оружия, по весу или по диапазону веса.
        /// </summary>
        public IEnumerable<FilterTypeItem> FilterTypes { get; } = new List<FilterTypeItem>
        {
            new FilterTypeItem(FilterType.Name, "Фильтр по названию"),
            new FilterTypeItem(FilterType.Weight, "Фильтр по весу"),
            new FilterTypeItem(FilterType.WeightRange, "Фильтр по диапазону")
        };

        /// <summary>
        /// Возвращает или задает выбранное оружие.
        /// </summary>
        public FilterTypeItem SelectedFilterType
        {
            get => _selectedFilterType;
            set
            {
                _selectedFilterType = value;
                OnPropertyChanged(nameof(SelectedFilterType));
                ApplyFilters();
            }
        }

        /// <summary>
        /// Возвращает или задает числовое значение для фильтрации по весу или другим числовым параметрам.
        /// </summary>
        public double? FilterNumericValueMin
        {
            get => _filterNumericValueMin;
            set
            {
                _filterNumericValueMin = value;
                OnPropertyChanged(nameof(FilterNumericValueMin));
                ApplyFilters();
            }
        }

        /// <summary>
        /// Возвращает или задает числовое значение для фильтрации по весу или другим числовым параметрам.
        /// </summary>
        public double? FilterNumericValueMax
        {
            get => _filterNumericValueMax;
            set
            {
                _filterNumericValueMax = value;
                OnPropertyChanged(nameof(FilterNumericValueMax));
                ApplyFilters();
            }
        }

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
        /// Возвращает или задает текст фильтрации по названию оружия.
        /// </summary>
        public string FilterText
        {
            get => _filterText;
            set
            {
                _filterText = value;
                OnPropertyChanged(nameof(FilterText));
                ApplyFilters();
            }
        }

        /// <summary>
        /// Возвращает или задает числовое значение для фильтрации по весу или другим числовым параметрам.
        /// </summary>
        public double? FilterNumericValue
        {
            get => _filterNumericValue;
            set
            {
                _filterNumericValue = value;
                OnPropertyChanged(nameof(FilterNumericValue));
                ApplyFilters();
            }
        }

        /// <summary>
        /// Возвращает или задает текстовое представление числового значения для фильтрации.
        /// </summary>
        public string FilterNumericValueText
        {
            get => _filterNumericValueText;
            set
            {
                _filterNumericValueText = value;
                if (double.TryParse(value, out double numericValue))
                {
                    FilterNumericValue = numericValue;
                }
                else
                {
                    FilterNumericValue = null;
                }
                OnPropertyChanged(nameof(FilterNumericValueText));
            }
        }

        /// <summary>
        /// Возвращает или задает текстовое представление минимального значения для фильтрации по диапазону.
        /// </summary>
        public string FilterNumericValueMinText
        {
            get => _filterNumericValueMinText;
            set
            {
                _filterNumericValueMinText = value;
                if (double.TryParse(value, out double numericValue))
                {
                    FilterNumericValueMin = numericValue;
                }
                else
                {
                    FilterNumericValueMin = null;
                }
                OnPropertyChanged(nameof(FilterNumericValueMinText));
            }
        }

        /// <summary>
        /// Возвращает или задает текстовое представление максимального значения для фильтрации по диапазону.
        /// </summary>
        public string FilterNumericValueMaxText
        {
            get => _filterNumericValueMaxText;
            set
            {
                _filterNumericValueMaxText = value;
                if (double.TryParse(value, out double numericValue))
                {
                    FilterNumericValueMax = numericValue;
                }
                else
                {
                    FilterNumericValueMax = null;
                }
                OnPropertyChanged(nameof(FilterNumericValueMaxText));
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
        /// Возвращает или задает флаг, будет ли форма генерации закрыта после завершения процесса.
        /// </summary>
        public bool IsCloseAfterCompleted
        {
            get => _isCloseAfterCompleted;
            set { _isCloseAfterCompleted = value; }
        }

        /// <summary>
        /// Возвращает отфильтрованную коллекцию оружия.
        /// </summary>
        public CollectionViewSource FilteredWeapons
        {
            get
            {
                if (_filteredWeapons == null)
                {
                    _filteredWeapons = new CollectionViewSource { Source = Weapons };
                }
                return _filteredWeapons;
            }
        }

        /// <summary>
        /// Применяет фильтры к коллекции оружия на основе установленных критериев.
        /// </summary>
        private void ApplyFilters()
        {
            _lastSelectedWeapon = SelectedWeapon;
            var filteredItems = _filtration.ApplyFilters(Weapons, FilterText, FilterNumericValue, FilterNumericValueMin, FilterNumericValueMax);
            FilteredWeapons.Source = new ObservableCollection<Weapon>(filteredItems);
            OnPropertyChanged(nameof(FilteredWeapons));

            if (_lastSelectedWeapon != null)
            {
                var newSelectedWeapon = filteredItems.FirstOrDefault(w => w.Id == _lastSelectedWeapon.Id);
                if (newSelectedWeapon != null)
                {
                    SelectedWeapon = newSelectedWeapon;
                }
            }
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
        /// <param name="filtration">
        /// Объект, реализующий интерфейс IFiltrable для фильтрации объектов типа Weapon.
        /// Этот объект отвечает за применение фильтров к коллекции оружия на основе
        /// заданных параметров, таких как название, вес или диапазон значений.
        /// </param>
        /// </summary>
        public MainViewModel(IFiltrable<Weapon> filtration)
        {
            _filtration = filtration;
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

        /// <summary>
        /// Генерирует случайные данные оружия.
        /// </summary>
        private void GenerateRandomData()
        {
            if (RandomWeaponsCount > 0)
            {
                LoadingForm processingForm = new LoadingForm(RandomWeaponsCount, IsCloseAfterCompleted, RandomWeaponGenerator.CreateRandomWeapon, AddRandomData);
                processingForm.Show();
            }

        }

        /// <summary>
        /// Добавляет случайные данные на форму.
        /// </summary>
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
