using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponsLib;

namespace Factories
{
    /// <summary>
    /// Абстрактная фабрика
    /// </summary>
    public abstract class AbstractFactory : IFactory
    {
        /// <summary>
        /// Создание огнестрельного оружия
        /// </summary>
        /// <returns>Огнестрельное оружие</returns>
        public abstract Firearm CreateFirearm();

        /// <summary>
        /// Создание холодного оружия
        /// </summary>
        /// <returns>Холодное оружие</returns>
        public abstract SteelArm CreateSteelArm();

    }
}
