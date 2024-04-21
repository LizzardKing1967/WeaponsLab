using Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponsLib;

namespace Client.ManipulationUtils
{
    internal class AxeEditor : WeaponEditor
    {
        public AxeEditor(WeaponRepository weaponModel) : base(weaponModel)
        {
        }

        public override void Delete(Weapon weapon)
        {
            Axe axe = (Axe)weapon;
            throw new NotImplementedException();
        }

        public override void Edit(Weapon weapon)
        {
            Axe axe = (Axe)weapon;
            AxeActionViewModel axeActionViewModel = new AxeActionViewModel(axe,"Add Axe", "Add", _weaponModel);
            AxeView axeActionView = new AxeView();
            axeActionView.DataContext = axeActionViewModel;
            axeActionView.ShowDialog();
        }
    }
}
