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
    /// <summary>
    /// Класс для редактирования и удаления объектов типа Axe.
    /// </summary>
    internal class AxeEditor : WeaponEditor
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса AxeEditor с указанным репозиторием оружия.
        /// </summary>
        /// <param name="parWeaponModel">Репозиторий оружия, который будет использоваться для доступа к данным.</param>
        public AxeEditor(WeaponRepository parWeaponModel) : base(parWeaponModel)
        {
        }

        /// <summary>
        /// Удаляет объект типа Axe.
        /// </summary>
        /// <param name="parWeapon">Объект типа Weapon, который требуется удалить.</param>
        public override void Delete(Weapon parWeapon)
        {
            Axe axe = (Axe)parWeapon;
            AxeActionViewModel axeActionViewModel = new AxeActionViewModel(axe, OperationMode.Delete, _weaponModel);
            AxeWindow axeActionView = new AxeWindow();
            axeActionView.DataContext = axeActionViewModel;
            axeActionView.ShowDialog();
        }

        /// <summary>
        /// Редактирует объект типа Axe.
        /// </summary>
        /// <param name="parWeapon">Объект типа Weapon, который требуется отредактировать.</param>
        public override void Edit(Weapon parWeapon)
        {
            Axe axe = (Axe)parWeapon;
            AxeActionViewModel axeActionViewModel = new AxeActionViewModel(axe, OperationMode.Edit, _weaponModel);
            AxeWindow axeActionView = new AxeWindow();
            axeActionView.DataContext = axeActionViewModel;
            axeActionView.ShowDialog();
        }
    }
}
