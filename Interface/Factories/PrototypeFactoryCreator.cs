using Interface;
using Interface.ManipulationUtils;
using Interface.Model;
using Interface.Utils;
using Interface.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WeaponsLib;

namespace Factories
{

    /// <summary>
    /// Фабричный метод для создания PrototypeFactoryCreator 
    /// </summary>
    public class PrototypeFactoryCreator : FactoryMethod
    {
        /// <summary>
        /// Создание объекта PrototypeFactoryCreator
        /// </summary>
        /// <returns>Объект PrototypeFactoryCreator</returns>
        public override IFactory CreateFactory()
        {
            Pistol pistol = new Pistol();
            Axe axe = new Axe();
            InitializeFirstPrototype(axe);
            InitializeSecondPrototype(pistol);
            return new PrototypeFactory(pistol, axe);
        }
        /// <summary>
        /// Инициализация первого прототипа
        /// </summary>
        /// <param name="parAxe">Параметр для инициализации прототипа</param>
        private void InitializeFirstPrototype(Axe parAxe)
        {
            AxeActionViewModel axeActionViewModel = new AxeActionViewModel(parAxe, OperationMode.Initialize);
            AxeWindow axeActionView = new AxeWindow();
            axeActionView.DataContext = axeActionViewModel;
            axeActionView.ShowDialog();

        }

        /// <summary>
        /// Инициализация второго прототипа
        /// </summary>
        /// <param name="parPistol">Параметр для инициализации прототипа</param>
        private void InitializeSecondPrototype(Pistol parPistol)
        {
            PistolActionViewModel pistolActionViewModel = new PistolActionViewModel(parPistol, OperationMode.Initialize);
            PistolWindow pistolActionView = new PistolWindow();
            pistolActionView.DataContext = pistolActionViewModel;
            pistolActionView.ShowDialog();
        }

        /// <summary>
        /// Получение текстового представление метода создания фабрики для представления в ComboBox
        /// </summary>
        /// <returns>Текстовое представление метода создания фабрики</returns>
        public override string ToString()
        {
            return "Фабрика прототипов";
        }
    }
}

