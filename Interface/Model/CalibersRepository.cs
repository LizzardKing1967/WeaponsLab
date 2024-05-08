using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponsLib;

namespace Interface.Model
{
    /// <summary>
    /// Статический репозиторий для списка калибров
    /// </summary>
    public static class CalibersRepository
    {
        /// <summary>
        /// Инициализация списка калибров
        /// </summary>
        private static List<Caliber> _calibers = new List<Caliber>
        {

                new Caliber(".45ACP", 120),
                new Caliber("9mm", 100),
                new Caliber("7.62mm", 150),
                new Caliber("5.56mm", 130)
        };
        /// <summary>
        /// Список калибров
        /// </summary>
        public static List<Caliber> Calibers
        {
            get { return _calibers; }
        }
    }
}
