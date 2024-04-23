using Interface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponsLib;

namespace Interface.ManipulationUtils
{
    internal class PistolEditor : WeaponEditor
    {
        public PistolEditor(WeaponRepository weaponModel) : base(weaponModel)
        {

        }

        public override void Delete(Weapon weapon)
        {
            Pistol pistol = (Pistol)weapon;
            throw new NotImplementedException();
        }

        public override void Edit(Weapon weapon)
        {
            Pistol pistol = (Pistol)weapon;
            throw new NotImplementedException();
        }
    }
}
