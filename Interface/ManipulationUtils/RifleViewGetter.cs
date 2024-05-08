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
    public class RifleViewGetter : WeaponViewGetter
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса RifleEditor с указанным репозиторием оружия.
        /// </summary>
        /// <param name="parWeaponModel">Репозиторий оружия, который будет использоваться для доступа к данным.</param>
        public RifleViewGetter(WeaponRepository parWeaponModel) : base(parWeaponModel)
        {
        }

        /// <summary>
        /// Вызывает представление для объекта типа Rifle.
        /// </summary>
        /// <param name="parWeapon">Объект Rifle</param>
        /// <param name="parOperationMode">Режим работы формы</param>
        public override void GetView(Weapon parWeapon, OperationMode parOperationMode)
        {
            Rifle rifle = (Rifle)parWeapon;
            RifleActionViewModel rifleActionViewModel = new RifleActionViewModel(rifle, parOperationMode, _weaponModel);
            RifleView rifleView = new RifleView();
            rifleView.DataContext = rifleActionViewModel;
            rifleView.ShowDialog();
        }
    }
}
