using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponsLib;

namespace Factories
{
    /// <summary>
    /// Фабрика прототипов
    /// </summary>
    public class PrototypeFactory : IFactory
    {
        /// <summary>
        /// Объект огнестрельного оружия
        /// </summary>
        private Firearm _firearm;

        /// <summary>
        /// Объект холодного оружия
        /// </summary>
        private SteelArm _steelArm;

        /// <summary>
        /// Конструктор фабрики
        /// </summary>
        /// <param name="parFirearm">Огнестрельное оружие</param>
        /// <param name="parSteelArm">Холодное оружие</param>
        public PrototypeFactory(Firearm parFirearm, SteelArm parSteelArm)
        {
            _firearm = parFirearm;
            _steelArm = parSteelArm;
        }

        /// <summary>
        /// Создание огнестрельного оружия
        /// </summary>
        /// <returns>Огнестрельное оружие</returns>
        public Firearm CreateFirearm()
        {
            return (Firearm) _firearm.Clone();
        }

        /// <summary>
        /// Создание холодного оружия
        /// </summary>
        /// <returns>Холодное оружие</returns>
        public SteelArm CreateSteelArm()
        {
            return (SteelArm) _steelArm.Clone();
        }
    }
}
