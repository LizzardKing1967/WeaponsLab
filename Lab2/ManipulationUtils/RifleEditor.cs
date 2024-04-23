using Interface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponsLib;

namespace Interface.ManipulationUtils
{
    internal class RifleEditor : WeaponEditor
    {
        public RifleEditor(WeaponRepository weaponModel) : base(weaponModel)
        {
        }

        public override void Delete(Weapon weapon)
        {
            Rifle rifle = (Rifle)weapon;

        }

        public override void Edit(Weapon weapon)
        {
            Rifle rifle = (Rifle)weapon;
            throw new NotImplementedException();
        }
    }
}
