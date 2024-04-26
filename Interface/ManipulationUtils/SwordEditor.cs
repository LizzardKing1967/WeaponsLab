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
    /// Класс для редактирования и удаления объектов типа Sword.
    /// </summary>
    public class SwordEditor : WeaponEditor
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса SwordEditor с указанным репозиторием оружия.
        /// </summary>
        /// <param name="parWeaponModel">Репозиторий оружия, который будет использоваться для доступа к данным.</param>
        public SwordEditor(WeaponRepository parWeaponModel) : base(parWeaponModel)
        {
        }

        /// <summary>
        /// Удаляет объект типа Sword.
        /// </summary>
        /// <param name="parWeapon">Объект типа Weapon, который требуется удалить.</param>
        public override void Delete(Weapon parWeapon)
        {
            Sword sword = (Sword)parWeapon;
            SwordActionViewModel swordActionViewModel = new SwordActionViewModel(sword, OperationMode.Delete, _weaponModel);
            SwordView swordView = new SwordView();
            swordView.DataContext = swordActionViewModel;
            swordView.ShowDialog();
        }

        /// <summary>
        /// Редактирует объект типа Sword.
        /// </summary>
        /// <param name="parWeapon">Объект типа Weapon, который требуется отредактировать.</param>
        public override void Edit(Weapon parWeapon)
        {
            Sword sword = (Sword)parWeapon;
            SwordActionViewModel swordActionViewModel = new SwordActionViewModel(sword, OperationMode.Edit, _weaponModel);
            SwordView swordView = new SwordView();
            swordView.DataContext = swordActionViewModel;
            swordView.ShowDialog();
        }
    }
}
