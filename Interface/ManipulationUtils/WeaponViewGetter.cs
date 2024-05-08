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
    /// Абстрактный класс для редактирования и удаления объектов типа Weapon.
    /// </summary>
    public abstract class WeaponViewGetter
    {
        /// <summary>
        /// Репозиторий оружия, используемый для доступа к данным.
        /// </summary>
        protected WeaponRepository _weaponModel;

        /// <summary>
        /// Инициализирует новый экземпляр класса WeaponEditor с указанным репозиторием оружия.
        /// </summary>
        /// <param name="parWeaponModel">Репозиторий оружия, который будет использоваться для доступа к данным.</param>
        public WeaponViewGetter(WeaponRepository parWeaponModel)
        {
            _weaponModel = parWeaponModel;
        }

        /// <summary>
        /// Абстрактный метод для вызова представления для оружия.
        /// </summary>
        /// <param name="parWeapon">Объект типа Weapon</param>
        /// <param name="parOperationMode">Режим работы формы</param>
        public abstract void GetView(Weapon parWeapon, OperationMode parOperationMode);
    }
}
