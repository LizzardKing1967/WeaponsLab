using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponsLib;

namespace Interface.Model
{
    public static class CalibersRepository
    {
        private static List<Caliber> _calibers = new List<Caliber>
        {

                new Caliber(".45ACP", 120),
                new Caliber("9mm", 100),
                new Caliber("7.62mm", 150),
                new Caliber("5.56mm", 130)
        };
        public static List<Caliber> Calibers
        {
            get { return _calibers; }
        }
    }
}
