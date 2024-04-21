using Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponsLib;

namespace Client.ManipulationUtils
{
    internal class SwordEditor : WeaponEditor
    {
        public SwordEditor(WeaponRepository weaponModel) : base(weaponModel)
        {
        }

        public override void Delete(Weapon weapon)
        {
            Sword sword = (Sword)weapon;
            throw new NotImplementedException();
        }

        public override void Edit(Weapon weapon)
        {
            Sword sword = (Sword)weapon;
            throw new NotImplementedException();
        }
    }
}
