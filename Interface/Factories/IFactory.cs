using WeaponsLib;

namespace Factories
{
    /// <summary>
    /// Общий интерфейс фабрики
    /// </summary>

    public interface IFactory
    {
        /// <summary>
        /// Создание огнестрельного оружия
        /// </summary>
        /// <returns>Огнестрельное оружие</returns>
        Firearm CreateFirearm();
        
        /// <summary>
        /// Создание холодного оружия
        /// </summary>
        /// <returns>Холодное оружие</returns>
        SteelArm CreateSteelArm();

    }
}
