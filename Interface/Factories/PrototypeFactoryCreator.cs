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
    public class PrototypeFactoryCreator : FactoryMethod
    {
        public override IFactory CreateFactory()
        {
            Pistol pistol = new Pistol();
            Axe axe = new Axe();
            InitializeFirstPrototype(axe);
            InitializeSecondPrototype(pistol);
            return new PrototypeFactory(pistol, axe);
        }

        private void InitializeFirstPrototype(Axe parAxe)
        {
            AxeActionViewModel axeActionViewModel = new AxeActionViewModel(parAxe, OperationMode.Initialize);
            AxeWindow axeActionView = new AxeWindow();
            axeActionView.DataContext = axeActionViewModel;
            axeActionView.ShowDialog();

        }

        private void InitializeSecondPrototype(Pistol parPistol)
        {
            PistolActionViewModel pistolActionViewModel = new PistolActionViewModel(parPistol, OperationMode.Initialize);
            PistolWindow pistolActionView = new PistolWindow();
            pistolActionView.DataContext = pistolActionViewModel;
            pistolActionView.ShowDialog();
        }


        public override string ToString()
        {
            return "Фабрика прототипов";
        }
    }
}

