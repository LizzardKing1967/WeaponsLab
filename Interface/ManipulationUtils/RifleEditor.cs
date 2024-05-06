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
    /// Класс для редактирования и удаления объектов типа Rifle.
    /// </summary>
    public class RifleEditor : WeaponEditor
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса RifleEditor с указанным репозиторием оружия.
        /// </summary>
        /// <param name="parWeaponModel">Репозиторий оружия, который будет использоваться для доступа к данным.</param>
        public RifleEditor(WeaponRepository parWeaponModel) : base(parWeaponModel)
        {
        }

        /// <summary>
        /// Удаляет объект типа Rifle.
        /// </summary>
        /// <param name="parWeapon">Объект типа Weapon, который требуется удалить.</param>
        public override void Delete(Weapon parWeapon)
        {
            Rifle rifle = (Rifle)parWeapon;
            RifleActionViewModel rifleActionViewModel = new RifleActionViewModel(rifle, OperationMode.Delete, _weaponModel);
            RifleView rifleView = new RifleView();
            rifleView.DataContext = rifleActionViewModel;
            rifleView.ShowDialog();
        }

        /// <summary>
        /// Редактирует объект типа Rifle.
        /// </summary>
        /// <param name="parWeapon">Объект типа Weapon, который требуется отредактировать.</param>
        public override void Edit(Weapon parWeapon)
        {
            Rifle rifle = (Rifle)parWeapon;
            RifleActionViewModel rifleActionViewModel = new RifleActionViewModel(rifle, OperationMode.Edit, _weaponModel);
            RifleView rifleView = new RifleView();
            rifleView.DataContext = rifleActionViewModel;
            rifleView.ShowDialog();
        }
    }
}
