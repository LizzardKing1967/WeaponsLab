using WeaponsLib;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Interface
{
    /// <summary>
    /// Основное окно приложения.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса MainWindow.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        /// <summary>
        /// Обработчик события автоматического создания столбцов в DataGrid.
        /// </summary>
        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "WeaponName")
            {
                e.Column.Header = "Название оружия";
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }
            else if (e.PropertyName == "Weight")
            {
                e.Column.Header = "Вес оружия";
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }
            else if (e.PropertyName == "DegreeOfDanger")
            {
                e.Column.Header = "Опасность оружия";
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }
        }
    }
}