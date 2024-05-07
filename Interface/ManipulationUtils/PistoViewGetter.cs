using Interface.Model;
using Interface.Utils;
using Interface.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponsLib;

namespace Interface.ManipulationUtils
{
    /// <summary>
    /// Класс для редактирования и удаления объектов типа Pistol.
    /// </summary>
    public class PistoViewGetter : WeaponViewGetter
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса PistolEditor с указанным репозиторием оружия.
        /// </summary>
        /// <param name="parWeaponModel">Репозиторий оружия, который будет использоваться для доступа к данным.</param>
        public PistoViewGetter(WeaponRepository parWeaponModel) : base(parWeaponModel)
        {
        }

        public override void GetView(Weapon parWeapon, OperationMode parOperationMode)
        {
            Pistol pistol = (Pistol)parWeapon;
            PistolActionViewModel pistolActionViewModel = new PistolActionViewModel(pistol, parOperationMode, _weaponModel);
            PistolWindow pistolActionView = new PistolWindow();
            pistolActionView.DataContext = pistolActionViewModel;
            pistolActionView.ShowDialog();
        }
    }
}
