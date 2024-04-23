﻿using WeaponsLib;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

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
