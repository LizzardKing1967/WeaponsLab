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
    public class PistolEditor : WeaponEditor
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса PistolEditor с указанным репозиторием оружия.
        /// </summary>
        /// <param name="parWeaponModel">Репозиторий оружия, который будет использоваться для доступа к данным.</param>
        public PistolEditor(WeaponRepository parWeaponModel) : base(parWeaponModel)
        {
        }
        /// <summary>
        /// Удаляет объект типа Pistol.
        /// </summary>
        /// <param name="parWeapon">Объект типа Weapon, который требуется удалить.</param>
        public override void Delete(Weapon parWeapon)
        {
            Pistol pistol = (Pistol)parWeapon;
            PistolActionViewModel pistolActionViewModel = new PistolActionViewModel(pistol, OperationMode.Delete, _weaponModel);
            PistolWindow pistolActionView = new PistolWindow();
            pistolActionView.DataContext = pistolActionViewModel;
            pistolActionView.ShowDialog();
        }

        /// <summary>
        /// Редактирует объект типа Pistol.
        /// </summary>
        /// <param name="parWeapon">Объект типа Weapon, который требуется отредактировать.</param>
        public override void Edit(Weapon parWeapon)
        {
            Pistol pistol = (Pistol)parWeapon;
            PistolActionViewModel pistolActionViewModel = new PistolActionViewModel(pistol, OperationMode.Edit, _weaponModel);
            PistolWindow pistolActionView = new PistolWindow();
            pistolActionView.DataContext = pistolActionViewModel;
            pistolActionView.ShowDialog();
        }
    }
}
