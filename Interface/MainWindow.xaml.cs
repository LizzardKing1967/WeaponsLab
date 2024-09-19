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
        
            public MainWindow(MainViewModel viewModel)
            {
                InitializeComponent();
                DataContext = viewModel;
            }
    }
}