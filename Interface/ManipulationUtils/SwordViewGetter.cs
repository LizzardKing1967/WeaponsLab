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
    public class SwordViewGetter : WeaponViewGetter
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса SwordEditor с указанным репозиторием оружия.
        /// </summary>
        /// <param name="parWeaponModel">Репозиторий оружия, который будет использоваться для доступа к данным.</param>
        public SwordViewGetter(WeaponRepository parWeaponModel) : base(parWeaponModel)
        {
        }

        /// <summary>
        /// Вызывает представление для объекта типа Sword.
        /// </summary>
        /// <param name="parWeapon">Объект Sword</param>
        /// <param name="parOperationMode">Режим работы формы</param>
        public override void GetView(Weapon parWeapon, OperationMode parOperationMode)
        {
            Sword sword = (Sword)parWeapon;
            SwordActionViewModel swordActionViewModel = new SwordActionViewModel(sword, parOperationMode, _weaponModel);
            SwordView swordView = new SwordView();
            swordView.DataContext = swordActionViewModel;
            swordView.ShowDialog();
        }
    }
    
}
