using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponsLib;

namespace Factories
{
    /// <summary>
    /// Фабрика тяжелого оружия
    /// </summary>
    public class HeavyWeaponsFactory : AbstractFactory
    {
        /// <summary>
        /// Создание винтовки
        /// </summary>
        /// <returns>Винтовка</returns>
        public override Firearm CreateFirearm()
        {
            return new Rifle();
        }

        /// <summary>
        /// Создание топора
        /// </summary>
        /// <returns>Топор</returns>
        public override SteelArm CreateSteelArm()
        {
            return new Axe();
        }
    }
}
