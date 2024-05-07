using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponsLib;

namespace Factories
{
    /// <summary>
    /// Фабрика легкого оружия
    /// </summary>
    public class LightWeaponsFactory : AbstractFactory
    {
        /// <summary>
        /// Создание пистолета
        /// </summary>
        /// <returns>Пистолет</returns>
        public override Firearm CreateFirearm()
        {
            return new Pistol();
        }

        /// <summary>
        /// Создание меча
        /// </summary>
        /// <returns>Меч</returns>
        public override SteelArm CreateSteelArm()
        {
            return new Sword();
        }
    }
}
