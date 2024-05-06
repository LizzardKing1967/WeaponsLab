﻿using Interface.Model;
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
    public abstract class WeaponEditor
    {
        /// <summary>
        /// Репозиторий оружия, используемый для доступа к данным.
        /// </summary>
        protected WeaponRepository _weaponModel;

        /// <summary>
        /// Инициализирует новый экземпляр класса WeaponEditor с указанным репозиторием оружия.
        /// </summary>
        /// <param name="parWeaponModel">Репозиторий оружия, который будет использоваться для доступа к данным.</param>
        public WeaponEditor(WeaponRepository parWeaponModel)
        {
            _weaponModel = parWeaponModel;
        }

        /// <summary>
        /// Абстрактный метод для редактирования объекта типа Weapon.
        /// </summary>
        /// <param name="parWeapon">Объект типа Weapon, который требуется отредактировать.</param>
        public abstract void Edit(Weapon parWeapon);

        /// <summary>
        /// Абстрактный метод для удаления объекта типа Weapon.
        /// </summary>
        /// <param name="parWeapon">Объект типа Weapon, который требуется удалить.</param>
        public abstract void Delete(Weapon parWeapon);
    }
}