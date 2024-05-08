using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories
{
    /// <summary>
    /// Фабричный метод для создания LightWeaponFactory
    /// </summary>
    public class LightWeaponsFactoryCreator : FactoryMethod
    {
        /// <summary>
        /// Создание LightWeaponFactory
        /// </summary>
        /// <returns>LightWeaponFactory</returns>
        public override IFactory CreateFactory()
        {
            return new LightWeaponsFactory();
        }

        /// <summary>
        /// Получение текстового представления фабрики для вывода в ComboBox
        /// </summary>
        /// <returns>Текстовое представление фабрики</returns>
        public override string ToString()
        {
            return "Абстрактная фабрика (Лёгкое оружие)";
        }
    }
}
