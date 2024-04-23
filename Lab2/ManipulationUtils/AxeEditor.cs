using Interface.Model;
using Interface.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponsLib;

namespace Interface.ManipulationUtils
{
    internal class AxeEditor : WeaponEditor
    {
        public AxeEditor(WeaponRepository weaponModel) : base(weaponModel)
        {
        }

        public override void Delete(Weapon weapon)
        {
            Axe axe = (Axe)weapon;
            AxeActionViewModel axeActionViewModel = new AxeActionViewModel(axe, OperationMode.Delete, _weaponModel);
            AxeView axeActionView = new AxeView();
            axeActionView.DataContext = axeActionViewModel;
            axeActionView.ShowDialog();
        }

        public override void Edit(Weapon weapon)
        {
            Axe axe = (Axe)weapon;
            AxeActionViewModel axeActionViewModel = new AxeActionViewModel(axe,OperationMode.Edit, _weaponModel);
            AxeView axeActionView = new AxeView();
            axeActionView.DataContext = axeActionViewModel;
            axeActionView.ShowDialog();
        }
    }
}
