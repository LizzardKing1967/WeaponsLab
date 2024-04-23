using Interface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponsLib;

namespace Interface.ManipulationUtils
{
    public abstract class WeaponEditor
    {
        protected WeaponRepository _weaponModel;

        public WeaponEditor(WeaponRepository weaponModel)
        {
            _weaponModel = weaponModel;
        }
        public abstract void Edit(Weapon weapon);

        public abstract void Delete(Weapon weapon);
    }
}
