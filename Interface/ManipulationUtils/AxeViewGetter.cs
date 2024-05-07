using Interface.Model;
using Interface.Utils;
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
    public class AxeViewGetter : WeaponViewGetter
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса AxeEditor с указанным репозиторием оружия.
        /// </summary>
        /// <param name="parWeaponModel">Репозиторий оружия, который будет использоваться для доступа к данным.</param>
        public AxeViewGetter(WeaponRepository parWeaponModel) : base(parWeaponModel)
        {
        }

        /// <summary>
        /// Редактирует объект типа Axe.
        /// </summary>
        /// <param name="parWeapon">Объект типа Weapon, который требуется отредактировать.</param>
        public override void GetView(Weapon parWeapon, OperationMode parOperationMode)
        {
            Axe axe = (Axe)parWeapon;
            AxeActionViewModel axeActionViewModel = new AxeActionViewModel(axe, parOperationMode, _weaponModel);
            AxeWindow axeActionView = new AxeWindow();
            axeActionView.DataContext = axeActionViewModel;
            axeActionView.ShowDialog();
        }
    }
}
