using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories
{
    /// <summary>
    /// Фабричный метод для создания HeavyWeaponFactory
    /// </summary>
    public class HeavyWeaponsFactoryCreator : FactoryMethod
    {
        /// <summary>
        /// Создание HeavyWeaponFactory
        /// </summary>
        /// <returns>HeavyWeaponFactory</returns>
        public override IFactory CreateFactory()
        {
            return new HeavyWeaponsFactory();
        }
        /// <summary>
        /// Получение текстового представления фабрики для вывода в ComboBox
        /// </summary>
        /// <returns>Текстовое представление фабрики</returns>
        public override string ToString()
        {
            return "Абстрактная фабрика (Тяжелое оружие)";
        }
    }
}
